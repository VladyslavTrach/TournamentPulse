using AutoMapper;
using Entity = TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Fighter;

namespace TournamentPulse.WebUI.Mapper
{
    public class FighterProfile : Profile
    {
        public FighterProfile()
        {
            CreateMap<Entity.Fighter, FighterListViewModel>()
                .ForMember(dest => dest.Academy, opt => opt.MapFrom(src => src.Academy.Name));
        }
    }
}
