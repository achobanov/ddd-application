using System.ComponentModel.DataAnnotations;
using Blog.Gateways.Web.Contracts;
using static Blog.Gateways.Web.Infrastructure.WebConstants.ViewConstants;

namespace Blog.Gateways.Web.Areas.Authentication.Models
{
    public class RegisterViewModel : BaseAuthenticationViewModel, IRegisterModelContract
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = Labels.ConfirmPassword)]
        [Compare(nameof(Password), ErrorMessage = ValidationMessages.PasswordsDoNotMatch)]
        public string ConfirmPassword { get; set; }
    }
}
