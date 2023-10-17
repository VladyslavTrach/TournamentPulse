using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.CategoryFighter;

namespace TournamentPulse.WebUI.Models.Tournament
{
    public class TournamentDetailsPageViewModel
    {
        public TournamentDetailsViewModel tournamentDetailsViewModel { get; set; }
        public ICollection<TournamentCategoryFighter> categoryFighterListViewModel { get; set;}
    }
}
