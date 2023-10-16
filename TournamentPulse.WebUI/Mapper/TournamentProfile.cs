using AutoMapper;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Tournament;

namespace TournamentPulse.WebUI.Mapper
{
    public class TournamentDetailsProfile : Profile
    {
        public TournamentDetailsProfile()
        {
            CreateMap<Tournament, TournamentDetailsViewModel>()
                .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.ImageName ?? "https://evolve-mma.com/wp-content/uploads/2022/09/gordon-ryan.jpg"))
                .ForMember(dest => dest.CreditCard, opt => opt.MapFrom(src => src.CreditCard ?? "Not Provided"))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone ?? "Not Provided"));
        }
    }

    public class TournamentEventsProfile : Profile
    {
        public TournamentEventsProfile()
        {
            CreateMap<Tournament, TournamentEventsViewModel>()
                .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => src.ImageName ?? "https://evolve-mma.com/wp-content/uploads/2022/09/gordon-ryan.jpg"));
        }
    }
}
