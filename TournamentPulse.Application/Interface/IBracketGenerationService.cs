using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface IBracketGenerationService
    {
        public void GenerateMatchesForFirstRound(int tournamentId, string categoryName);
        void GenerateMatchesForNextRound(int tournamentId, string categoryName);
        List<Fighter> GetFightersFromMatches(ICollection<Match> matches);
    }
}
