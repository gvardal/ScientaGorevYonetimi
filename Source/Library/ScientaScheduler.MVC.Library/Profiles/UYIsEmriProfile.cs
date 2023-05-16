using AutoMapper;
using ScientaScheduler.MVC.Library.Dtos;
using ScientaScheduler.MVC.Library.Models;

namespace ScientaScheduler.MVC.Library.Profiles
{
    public class UYIsEmriProfile : Profile
    {
        public UYIsEmriProfile()
        {
            CreateMap<UYIsEmri, UYIsEmriDto>()
                .ForMember(d => d.IsEmriKodu, s => s.MapFrom(src => src.IsEmriKodu!.ToString()));

            CreateMap<P_UYIsEmriDurumu, UYIsEmriDurumuDto>();
        }
    }
}
