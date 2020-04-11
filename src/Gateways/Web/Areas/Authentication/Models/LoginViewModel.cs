using System.ComponentModel.DataAnnotations;
using Blog.Gateways.Web.Contracts;
using static Blog.Gateways.Web.Common.WebConstants.ViewConstants;

namespace Blog.Gateways.Web.Authentication.Models
{
    public class LoginViewModel : ILoginModelContract
    {
        [Required]
        [Display(Name = UsernameLabel)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = PasswordLabel)]
        public string Password { get; set; }

        public string ReturnUrl { get;set; }
    }
}
