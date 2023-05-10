using AutoMapper;
using ScientaScheduler.MVC.Models.Domain;
using ScientaScheduler.MVC.Models.ViewModels;

namespace ScientaScheduler.MVC.Models.MapingProfiles
{
    public class UYIsEmriProfile : Profile
    {
        public UYIsEmriProfile()
        {
            CreateMap<UYIsEmri, UYIsEmriDTO>()
                .ForMember(d=> d.IsEmriKodu, s=> s.MapFrom(src => src.IsEmriKodu!.ToString()));
        }
    }
}
