using AutoMapper;
using EnduranceJudge.Application.Core.Exceptions;
using EnduranceJudge.Core;
using EnduranceJudge.Core.Extensions;
using EnduranceJudge.Core.Mappings;
using EnduranceJudge.Core.Utilities;
using EnduranceJudge.Gateways.Desktop.Core.Components.Templates.ListItem;
using EnduranceJudge.Gateways.Desktop.Services;
using EnduranceJudge.Gateways.Desktop.Views.Content.Event.Dependants.Competitions;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using CollectionExtensions = System.Collections.ObjectModel.CollectionExtensions;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public abstract class ShardableFormBase : FormBase
    {
        private static readonly Type ObservableCollectionAddRangeExtensionType = typeof(CollectionExtensions);

        private readonly Dictionary<string, FormShardModel> shards = new();
        private readonly Type thisType;

        protected ShardableFormBase(INavigationService navigation) : base(navigation)
        {
            this.thisType = this.GetType();

            if (this is IPrincipalForm)
            {
                this.InitializeShards();
            }
        }

        public void UpdateDependantItems()
        {
            foreach (var (key, shard) in this.shards)
            {
                this.UpdateListItems(key, shard);
            }
        }

        private Action<object> GetDependantSubmitAction(string key)
        {
            Action<object> action = obj =>
            {
                if (obj is not DependantFormBase dependant)
                {
                    throw new AppException("kur");
                }

                this.UpdateDependants(key, dependant);
            };

            return action;
        }

        private void UpdateDependants(string key, DependantFormBase dependant)
        {
            if (!this.shards.ContainsKey(key))
            {
                throw new AppException($"Cannot add dependant - key '{key}' does not exist in dependants dictionary.");
            }

            var shard = this.shards[key];

            shard.AddOrUpdateDependant(dependant);
            this.UpdateListItems(key, shard);
        }

        private void UpdateListItems(string key, FormShardModel shard)
        {
            var listItems = new List<ListItemViewModel>();
            foreach (var item in shard.GetDependants())
            {
                if (item is not DependantFormBase dependant)
                {
                    throw new Exception("kur");
                }

                var listItem = this.ConvertToListItem(key, dependant, typeof(CompetitionView));
                listItems.Add(listItem);
            }

            shard.RefreshItems(listItems);
        }

        private ListItemViewModel ConvertToListItem(string key, DependantFormBase dependant, Type view)
        {
            var submitAction = this.GetDependantSubmitAction(key);

            var navigateToUpdateAction = this.NavigateToDependantUpdateDelegate(view, dependant, submitAction);
            var command = new DelegateCommand(navigateToUpdateAction);

            var listItem = dependant.ToListItem(command);
            return listItem;
        }

        private void InitializeShards()
        {
            var principalFormType = DesktopConstants.Types.PrincipalForm;

            var dependsOnInterfaces = this.thisType
                .GetInterfaces()
                .Where(type => principalFormType.IsAssignableFrom(type) && principalFormType != type)
                .ToList();

            var thisProperties = ReflectionUtilities.GetProperties(this.thisType);

            foreach (var dependsOnInterface in dependsOnInterfaces)
            {
                this.InitializeShard(dependsOnInterface, thisProperties);
            }
        }

        private void InitializeShard(Type hasDependantsInterface, PropertyInfo[] thisProperties)
        {
            var dependantType = hasDependantsInterface
                .GetGenericArguments()
                .First();

            var dependantKey = dependantType.FullName;
            var interfaceProperties = ReflectionUtilities.GetProperties(hasDependantsInterface);

            var shard = this.CreatePrincipalShardModel(dependantType, interfaceProperties);
            this.shards.Add(dependantKey!, shard);

            this.SetNavigateToCreateCommand(dependantKey, hasDependantsInterface, interfaceProperties, thisProperties);
        }

        private FormShardModel CreatePrincipalShardModel(
            Type dependantType,
            PropertyInfo[] interfaceProperties)
        {
            var dependantCollectionType = CoreConstants.Types.ListGeneric.MakeGenericType(dependantType);
            var itemsCollectionType = DesktopConstants.Types.ObservableListItems;

            var dependantsCollectionInfo = interfaceProperties.First(t =>
                dependantCollectionType.IsAssignableFrom(t.PropertyType));

            var itemsCollectionInfo = interfaceProperties.First(t =>
                itemsCollectionType.IsAssignableFrom(t.PropertyType));

            // Dependants.AddOrUpdate(...)
            var addOrUpdateObjectStaticMethod = CoreConstants.Types.ObjectExtensions
                .GetMethod(nameof(IObjectExtensions.AddOrUpdateObject))
                !.MakeGenericMethod(dependantType);

            // Items.Clear()
            var clearItemsMethod = itemsCollectionType.GetMethod(nameof(Collection<object>.Clear));

            // Items.AddRange(..)
            var addItemsStaticMethod = ObservableCollectionAddRangeExtensionType
                .GetMethod(nameof(CollectionExtensions.AddRange))
                !.MakeGenericMethod(DesktopConstants.Types.ListItemViewModel);

            var dependantsCollection = dependantsCollectionInfo.GetValue(this);
            var itemsCollection = itemsCollectionInfo.GetValue(this);

            var principalShard = new FormShardModel(
                dependantsCollection,
                itemsCollection,
                addOrUpdateObjectStaticMethod,
                clearItemsMethod,
                addItemsStaticMethod);

            return principalShard;
        }

        private void SetNavigateToCreateCommand(
            string key,
            Type hasDependantsInterface,
            PropertyInfo[] interfaceProperties,
            PropertyInfo[] thisProperties)
        {
            var viewType = this.GetViewType(hasDependantsInterface);

            var submitAction = this.GetDependantSubmitAction(key);
            var navigateAction = this.NavigateToDependantCreateDelegate(viewType, submitAction);
            var navigateCommand = new DelegateCommand(navigateAction);

            var navigateCommandName = interfaceProperties
                .First(t => DesktopConstants.Types.DelegateCommand.IsAssignableFrom(t.PropertyType))
                !.Name;

            var navigateCommandInfo = thisProperties.First(t => t.Name == navigateCommandName);

            var setter = navigateCommandInfo!.GetSetMethod(nonPublic: true);
            if (setter == null)
            {
                throw new Exception($"Add private setter to {navigateCommandInfo.Name}");
            }

            navigateCommandInfo.SetValue(this, navigateCommand);
        }

        private Type GetViewType(Type hasDependantsInterface)
        {
            var viewType = hasDependantsInterface
                .GetInterfaces()
                .Single(type => type.Name == DesktopConstants.Types.HasView.Name)
                .GetGenericArguments()
                .Single();

            return viewType;
        }

        private Action NavigateToDependantCreateDelegate(Type viewType, Action<object> action)
        {
            return () => this.Navigation.ChangeTo(viewType, action);
        }

        private Action NavigateToDependantUpdateDelegate(Type viewType, object data, Action<object> action)
        {
            return () => this.Navigation.ChangeTo(viewType, data, action);
        }

    }

    public class ShardableFormMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            profile.CreateMap<object, ShardableFormBase>()
                .AfterMap((_, destination) => destination.UpdateDependantItems());
        }
    }
}
