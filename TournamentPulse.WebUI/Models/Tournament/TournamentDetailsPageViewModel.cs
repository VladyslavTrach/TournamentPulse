using TournamentPulse.WebUI.Models.CategoryFighter;

namespace TournamentPulse.WebUI.Models.Tournament
{
    public class TournamentDetailsPageViewModel
    {
        public TournamentDetailsViewModel tournamentDetailsViewModel { get; set; }
        public List<CategoryFighterListViewModel> categoryFighterListViewModel { get; set; }
    }
}
