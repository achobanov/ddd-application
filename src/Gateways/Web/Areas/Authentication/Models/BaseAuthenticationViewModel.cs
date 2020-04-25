using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using static Blog.Gateways.Web.Common.WebConstants.ViewConstants;

namespace Blog.Gateways.Web.Areas.Authentication.Models
{
    public abstract class BaseAuthenticationViewModel
    {
        [Required]
        [Display(Name = Labels.Username)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = Labels.Password)]
        public string Password { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }
}
