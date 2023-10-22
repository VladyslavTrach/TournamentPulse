using TournamentPulse.WebUI.Models.Fighter;

namespace TournamentPulse.WebUI.Models.Match
{
    public class CategoryMatchListViewModel
    {
        public string Category { get; set; }
        public List<MatchViewModel> Matches { get; set; }
    }
}
