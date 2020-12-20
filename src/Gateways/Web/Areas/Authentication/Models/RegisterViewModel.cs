using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EnduranceContestManager.Core.Mappings;
using EnduranceContestManager.Gateways.Web.Contracts;
using EnduranceContestManager.Gateways.Web.Infrastructure;
using static EnduranceContestManager.Gateways.Web.Infrastructure.WebConstants.ViewConstants;

namespace EnduranceContestManager.Gateways.Web.Areas.Authentication.Models
{
    public class RegisterViewModel : BaseAuthenticationViewModel, IRegisterContext, IMapExplicitly
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = WebConstants.ViewConstants.Labels.ConfirmPassword)]
        [Compare(nameof(Password), ErrorMessage = WebConstants.ViewConstants.ValidationMessages.PasswordsDoNotMatch)]
        public string ConfirmPassword { get; set; }

        public void CreateMap(Profile mapper)
            => mapper
                .CreateMap<LoginViewModel, RegisterViewModel>()
                .ForMember(x => x.ConfirmPassword, opt => opt.MapFrom(y => y.Password));
    }
}
