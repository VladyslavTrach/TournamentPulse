using AutoMapper;
using TournamentPulse.WebAPI.DTOs.Fighter;

namespace TournamentPulse.WebAPI.Mapper
{
    public class FighterProfile : Profile
    {
        public FighterProfile()
        {
            CreateMap<CreateFighterDTO, Core.Entities.Fighter>();
            CreateMap<Core.Entities.Fighter, ReadFighterDTO>();
        }
    }
}
