using System.ComponentModel.DataAnnotations;
using Blog.Gateways.Web.Contracts;
using static Blog.Gateways.Web.Common.WebConstants.ViewConstants;

namespace Blog.Gateways.Web.Areas.Authentication.Models
{
    public class LoginViewModel : BaseAuthenticationViewModel, ILoginModelContract
    {
        [Display(Name = Labels.RememberMe)]
        public bool RememberMe { get; set; }
    }
}
