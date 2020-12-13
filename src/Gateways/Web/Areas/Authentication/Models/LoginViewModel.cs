using System.ComponentModel.DataAnnotations;
using Blog.Common.Mappings;
using Blog.Gateways.Web.Contracts;
using static Blog.Gateways.Web.Infrastructure.WebConstants.ViewConstants;

namespace Blog.Gateways.Web.Areas.Authentication.Models
{
    public class LoginViewModel : BaseAuthenticationViewModel, ILoginContext, IMapFrom<RegisterViewModel>
    {
        [Display(Name = Labels.RememberMe)]
        public bool RememberMe { get; set; }
    }
}
