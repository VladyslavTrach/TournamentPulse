using AutoMapper;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Match;

namespace TournamentPulse.WebUI.Mapper
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Score1, opt => opt.MapFrom(src => src.Score1))
                .ForMember(dest => dest.Score2, opt => opt.MapFrom(src => src.Score2))
                .ForMember(dest => dest.MatchStatus, opt => opt.MapFrom(src => src.MatchStatus))
                .ForMember(dest => dest.WinningMethod, opt => opt.MapFrom(src => src.WinningMethod))
                .ForMember(dest => dest.TournamentId, opt => opt.MapFrom(src => src.TournamentId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Fighter1Id, opt => opt.MapFrom(src => src.Fighter1Id))
                .ForMember(dest => dest.Fighter2Id, opt => opt.MapFrom(src => src.Fighter2Id))
                .ForMember(dest => dest.WinnerId, opt => opt.MapFrom(src => src.WinnerId));

            CreateMap<MatchViewModel, Match>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Score1, opt => opt.MapFrom(src => src.Score1))
                .ForMember(dest => dest.Score2, opt => opt.MapFrom(src => src.Score2))
                .ForMember(dest => dest.MatchStatus, opt => opt.MapFrom(src => src.MatchStatus))
                .ForMember(dest => dest.WinningMethod, opt => opt.MapFrom(src => src.WinningMethod))
                .ForMember(dest => dest.TournamentId, opt => opt.MapFrom(src => src.TournamentId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Fighter1Id, opt => opt.MapFrom(src => src.Fighter1Id))
                .ForMember(dest => dest.Fighter2Id, opt => opt.MapFrom(src => src.Fighter2Id))
                .ForMember(dest => dest.WinnerId, opt => opt.MapFrom(src => src.WinnerId));
        }
    }
}
