using EnduranceContestManager.Common.Contracts;
using Moq;

namespace Blog.Web.IntegrationTests
{

    public class Mocks
    {
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
