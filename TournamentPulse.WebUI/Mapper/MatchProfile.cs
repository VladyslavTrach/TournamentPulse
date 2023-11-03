using AutoMapper;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Repository;
using TournamentPulse.Core.Entities;
using TournamentPulse.Core.Enums;
using TournamentPulse.WebUI.Models.Match;

namespace TournamentPulse.WebUI.Mapper
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Round, opt => opt.MapFrom(src => src.Round))
                .ForMember(dest => dest.Score1, opt => opt.MapFrom(src => src.Score1))
                .ForMember(dest => dest.Score2, opt => opt.MapFrom(src => src.Score2))
                .ForMember(dest => dest.MatchStatus, opt => opt.MapFrom(src => src.MatchStatus))
                .ForMember(dest => dest.WinningMethod, opt => opt.MapFrom(src => src.WinningMethod))
                .ForMember(dest => dest.TournamentId, opt => opt.MapFrom(src => src.TournamentId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.Fighter1, opt => opt.MapFrom(src => src.Fighter1.FullName))
                .ForMember(dest => dest.Fighter2, opt => opt.MapFrom(src => src.Fighter2.FullName))
                .ForMember(dest => dest.Winner, opt => opt.MapFrom(src => src.Winner.FullName))
                .ForMember(dest => dest.Score1, opt => opt.NullSubstitute(0))
                .ForMember(dest => dest.Score2, opt => opt.NullSubstitute(0))
                .ForMember(dest => dest.WinningMethod, opt => opt.NullSubstitute(WinningMethodEnum.NoWinYet.ToString()));

        }
    }
}
