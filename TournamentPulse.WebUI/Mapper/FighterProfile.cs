using AutoMapper;
using Entity = TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Fighter;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data.Generator;

namespace TournamentPulse.WebUI.Mapper
{
    public class FighterProfile : Profile
    {
        public FighterProfile()
        {
            CreateMap<Fighter, FighterListViewModel>()
                .ForMember(dest => dest.Academy, opt => opt.MapFrom(src => src.Academy.Name));

            CreateMap<Fighter, FighterRecordModel>();

            CreateMap<FighterRecordModel, Fighter>();

            CreateMap<Fighter, FighterWithMatchesViewModel>()
                .ForMember(dest => dest.Academy, opt => opt.MapFrom(src => src.Academy.Name));
        }
    }

}
