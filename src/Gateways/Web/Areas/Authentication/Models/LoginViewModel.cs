using System.ComponentModel.DataAnnotations;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Gateways.Web.Contracts;
using EnduranceContestManager.Gateways.Web.Infrastructure;
using static EnduranceContestManager.Gateways.Web.Infrastructure.WebConstants.ViewConstants;

namespace EnduranceContestManager.Gateways.Web.Areas.Authentication.Models
{
    public class LoginViewModel : BaseAuthenticationViewModel, ILoginContext, IMapFrom<RegisterViewModel>
    {
        [Display(Name = WebConstants.ViewConstants.Labels.RememberMe)]
        public bool RememberMe { get; set; }
    }
}
