namespace Blog.Web.IntegrationTests
{
    using Blog.Application.Contracts;
    using Moq;
    using MyTested.AspNetCore.Mvc;

    public class Mocks
    {
        public static IAuthenticationContext IdentityContext
        {
            get
            {
                var currentUserMock = new Mock<IAuthenticationContext>();

                currentUserMock
                    .SetupGet(u => u.UserId)
                    .Returns(TestUser.Identifier);

                return currentUserMock.Object;
            }
        }

        public static IDateTime DateTime
        {
            get
            {
                var currentUserMock = new Mock<IDateTime>();

                currentUserMock
                    .SetupGet(u => u.Now)
                    .Returns(TestData.TestNow);

                return currentUserMock.Object;
            }
        }
    }
}
