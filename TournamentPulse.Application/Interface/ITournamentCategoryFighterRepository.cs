using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface ITournamentCategoryFighterRepository
    {
        bool AddTCFRecord(TournamentCategoryFighter tcf);
        ICollection<TournamentCategoryFighter> GetCategoryFighter(int tournamentId);
        ICollection<Fighter> GetFightersInCategoryAndTournament(int tournamentId, int categoryId);
    }
}