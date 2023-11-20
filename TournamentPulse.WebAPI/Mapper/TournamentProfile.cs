using AutoMapper;
using TournamentPulse.WebAPI.DTOs.Tournament;

namespace TournamentPulse.WebAPI.Mapper
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<CreateTournamentDTO, Core.Entities.Tournament>();
            CreateMap<Core.Entities.Tournament, ReadTournamentDTO>();
        }
    }
}
