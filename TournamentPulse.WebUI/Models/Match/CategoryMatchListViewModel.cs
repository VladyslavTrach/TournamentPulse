namespace TournamentPulse.WebUI.Models.Match
{
    public class CategoryMatchListViewModel
    {
        public int TotalRounds { get; set; }
        public string Category { get; set; }
        public List<MatchViewModel> Matches { get; set; }
    }
}
