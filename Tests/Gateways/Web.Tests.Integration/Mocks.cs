using Blog.Application.Contracts;
using Blog.Common.Contracts;
using Moq;
using MyTested.AspNetCore.Mvc;

namespace Blog.Web.Tests.Integration
{
    public class Mocks
    {
        public static IAuthenticationContext IdentityContext
        {
            get
            {
                var authenticationContext = new Mock<IAuthenticationContext>();

                authenticationContext
                    .SetupGet(u => u.Username)
                    .Returns(TestUser.Identifier);

                return authenticationContext.Object;
            }
        }

        public static IDateTime DateTime
        {
            get
            {
                var dateTimeMock = new Mock<IDateTime>();

                dateTimeMock
                    .SetupGet(u => u.Now)
                    .Returns(TestData.TestNow);

                return dateTimeMock.Object;
            }
        }
    }
}
