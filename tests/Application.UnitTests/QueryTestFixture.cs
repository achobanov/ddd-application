using AutoMapper;
using Xunit;

namespace Blog.Application.UnitTests
{
    // Tests will be fixed in: https://github.com/achobanov/web-application/issues/21
    public abstract class BaseQueryTests : BaseTests
    {
        public BaseQueryTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMappingProfile>();
            });

            this.Mapper = configurationProvider.CreateMapper();

            //var identityMock = new Mock<IIdentity>();

            //identityMock
            //    .Setup(i => i.GetUserName(It.IsAny<string>()))
            //    .Returns(Task.FromResult("Test User"));

            //this.Identity = identityMock.Object;
        }

        public IMapper Mapper { get; }

        // public IIdentity Identity { get; }
    }

    [CollectionDefinition("QueryTests")]
    public class QueryCollection : ICollectionFixture<BaseQueryTests> { }
}