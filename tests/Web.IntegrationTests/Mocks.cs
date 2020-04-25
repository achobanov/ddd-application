namespace Blog.Web.IntegrationTests
{
    using Blog.Application.Contracts;
    using Blog.Common.Contracts;
    using Moq;
    using MyTested.AspNetCore.Mvc;

    public class Mocks
    {
        public static IAuthenticationContract IdentityContext
        {
            get
            {
                var currentUserMock = new Mock<IAuthenticationContract>();

                currentUserMock
                    .SetupGet(u => u.Username)
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
