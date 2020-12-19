using EnduranceContestManager.Application.Contracts;
using EnduranceContestManager.Common.Contracts;
using Moq;
using MyTested.AspNetCore.Mvc;

namespace Blog.Web.IntegrationTests
{

    public class Mocks
    {
        public static IAuthenticationContext IdentityContext
        {
            get
            {
                var currentUserMock = new Mock<IAuthenticationContext>();

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
