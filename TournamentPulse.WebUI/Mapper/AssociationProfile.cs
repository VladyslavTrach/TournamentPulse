using AutoMapper;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Association;

public class AssociationProfile : Profile
{
    public AssociationProfile()
    {
        CreateMap<Association, AssociationListViewModel>()
            .ForMember(dest => dest.AcademiesCnt, opt => opt.MapFrom(src => src.Academies.Count))
            .ForMember(dest => dest.FightersCnt, opt => opt.MapFrom(src => src.Academies.Sum(a => a.Fighters != null ? a.Fighters.Count : 0)));

        CreateMap<Association, AssociationDetailsListViewModel>()
            .ForMember(dest => dest.AcademiesCnt, opt => opt.MapFrom(src => src.Academies.Count))
            .ForMember(dest => dest.FightersCnt, opt => opt.MapFrom(src => src.Academies.Sum(a => a.Fighters != null ? a.Fighters.Count : 0)));
    }
}
