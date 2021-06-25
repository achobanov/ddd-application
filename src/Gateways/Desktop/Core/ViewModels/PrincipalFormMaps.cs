using AutoMapper;
using EnduranceJudge.Core.Mappings;

namespace EnduranceJudge.Gateways.Desktop.Core.ViewModels
{
    public class PrincipalFormMaps : ICustomMapConfiguration
    {
        public void AddMaps(IProfileExpression profile)
        {
            profile.CreateMap<object, PrincipalFormBase>()
                .AfterMap((_, destination) => destination.UpdateDependantItems());
        }
    }
}
