using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.CategoryFighter;
using TournamentPulse.WebUI.Models.Match;

namespace TournamentPulse.WebUI.Models.Tournament
{
    public class TournamentDetailsPageViewModel
    {
        public TournamentDetailsViewModel tournamentDetailsViewModel { get; set; }
        public List<CategoryFighterListViewModel> categoryFighterListViewModel { get; set; }
        public List<MatchViewModel> matchListViewModel { get; set; }
    }
}
