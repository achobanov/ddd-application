using System.ComponentModel.DataAnnotations;
using Blog.Gateways.Web.Contracts;
using static Blog.Gateways.Web.Common.WebConstants.ViewConstants;

namespace Blog.Gateways.Web.Authentication.Models
{
    public class RegisterViewModel : LoginViewModel, IRegisterModelContract
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = ConfirmPasswordLabel)]
        public string ConfirmPassword { get; set; }
    }
}
