using AutoMapper;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Academy;

namespace TournamentPulse.WebUI.Mapper
{
    public class AcademyProfile : Profile
    {
        public AcademyProfile()
        {
            CreateMap<Academy, AcademyListViewModel>()
                .ForMember(dest => dest.Association, opt => opt.MapFrom(src => src.Association.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.FightersCnt, opt => opt.MapFrom(src => src.Fighters.Count));

            CreateMap<Academy, AcademyDetailsViewModel>()
                .ForMember(dest => dest.Association, opt => opt.MapFrom(src => src.Association.Name))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.FightersCnt, opt => opt.MapFrom(src => src.Fighters.Count));
        }
    }
}
