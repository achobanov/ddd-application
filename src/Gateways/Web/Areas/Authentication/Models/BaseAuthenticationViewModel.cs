using EnduranceContestManager.Gateways.Web.Infrastructure;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using static EnduranceContestManager.Gateways.Web.Infrastructure.WebConstants.ViewConstants;

namespace EnduranceContestManager.Gateways.Web.Areas.Authentication.Models
{
    public abstract class BaseAuthenticationViewModel
    {
        [Required]
        [Display(Name = WebConstants.ViewConstants.Labels.Username)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = WebConstants.ViewConstants.Labels.Password)]
        public string Password { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }
}
