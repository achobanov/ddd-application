using EnduranceContestManager.Core.Interfaces;
using EnduranceContestManager.Core.Utilities;
using EnduranceContestManager.Gateways.Persistence.Data.Contests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using static EnduranceContestManager.Gateways.Persistence.Core.PersistenceCoreConstants;

namespace EnduranceContestManager.Gateways.Persistence.Core.Services.Implementations
{
    public class BackupService : IBackupService
    {
        private readonly IEncryptionService encryption;
        private readonly IFileService file;
        private readonly ISerializationService serialization;

        public BackupService(IEncryptionService encryption, IFileService file, ISerializationService serialization)
        {
            this.encryption = encryption;
            this.file = file;
            this.serialization = serialization;
        }

        public async Task Create<TDataStore>(TDataStore dbContext)
            where TDataStore : IDataStore
        {
            var dbSetProperties = this.GetEntitySets<TDataStore>();

            var data = dbSetProperties.ToDictionary(
                propertyInfo => propertyInfo.Name,
                propertyInfo => this.serialization.Serialize(
                    propertyInfo.GetValue(dbContext)));

            var serialized = this.serialization.Serialize(data);
            var encrypted = this.encryption.Encrypt(serialized);

            await this.file.Create(BackupFileName, encrypted);
        }

        public async Task Restore<TDataStore>(TDataStore dbContext)
            where TDataStore : DbContext
        {
            var encrypted = await this.file.Read(BackupFileName);
            if (string.IsNullOrEmpty(encrypted))
            {
                return;
            }

            var decrypted = this.encryption.Decrypt(encrypted);
            var deserialized = this.serialization.Deserialize<Dictionary<string, string>>(decrypted);

            var contests = this.serialization.Deserialize<List<ContestData>>(deserialized["Contests"]);
            var trials = this.serialization.Deserialize<List<TrialData>>(deserialized["Trials"]);

            await dbContext.AddRangeAsync(contests);
            await dbContext.AddRangeAsync(trials);

            await dbContext.SaveChangesAsync();
            ;
            // var dbContextType = typeof(TDataStore);
            // var dbSetProperties = this.GetEntitySets<TDataStore>();
            //
            // foreach (var (setName, serializedSet) in deserialized)
            // {
            //     this.Restore(setName, serializedSet, dbContext, dbContextType, dbSetProperties);
            // }
        }

        private IList<PropertyInfo> GetEntitySets<TDbContext>()
        {
            var properties = ReflectionUtilities.GetProperties<TDbContext>(BindingFlags.Public | BindingFlags.Instance);
            var dbSetProperties = properties
                .Where(propertyInfo =>
                    propertyInfo.PropertyType.IsGenericType &&
                    (propertyInfo.PropertyType.BaseType?.IsAssignableFrom(Types.DbSet) ?? false))
                .ToList();

            return dbSetProperties;
        }

        private void Restore(
            string dbSetName,
            string serializedEntityCollection,
            object dbContext,
            Type dbContextType,
            IList<PropertyInfo> dbSetProperties)
        {
            var entitySetProperty = dbSetProperties.FirstOrDefault(property => property.Name == dbSetName);
            if (entitySetProperty == null)
            {
                return;
            }

            var entityType = entitySetProperty.PropertyType
                .GetGenericArguments()
                .First();


            var entityCollectionType = Types.List.MakeGenericType(entityType);
            var entityCollection = this.serialization.Deserialize(serializedEntityCollection, entityCollectionType);

            var entitySetType = Types.DbSet.MakeGenericType(entityType);
            var addRangeMethod = entitySetType.GetMethod("AddRange", new[] { entityCollectionType });

            // Expression
            // db =>
            var dbContextParam = Expression.Parameter(dbContextType, "dbContext");

            // db => db.<DbSet property>
            var dbSetAccessor = Expression.Property(dbContextParam, dbSetName);

            // entities
            var entityCollectionParam = Expression.Parameter(entityCollectionType, "entities");

            // db => db.SetName.AddRange(entities)
            var call = Expression.Call(dbSetAccessor, addRangeMethod, entityCollectionParam);

            var lambdaType = Types.Action.MakeGenericType(dbContextType, entityCollectionType);
            var lambda = Expression.Lambda(lambdaType, call, dbContextParam, entityCollectionParam);

            lambda.Compile().DynamicInvoke(dbContext, entityCollection);
        }
    }
}
