using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Blog.Common.Mappings;
using Blog.Gateways.Web.Contracts;
using static Blog.Gateways.Web.Infrastructure.WebConstants.ViewConstants;

namespace Blog.Gateways.Web.Areas.Authentication.Models
{
    public class RegisterViewModel : BaseAuthenticationViewModel, IRegisterContext, IMapExplicitly
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = Labels.ConfirmPassword)]
        [Compare(nameof(Password), ErrorMessage = ValidationMessages.PasswordsDoNotMatch)]
        public string ConfirmPassword { get; set; }

        public void CreateMap(Profile mapper)
            => mapper
                .CreateMap<LoginViewModel, RegisterViewModel>()
                .ForMember(x => x.ConfirmPassword, opt => opt.MapFrom(y => y.Password));
    }
}
