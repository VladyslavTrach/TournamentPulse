using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface ITournamentCategoryFighterRepository
    {
        bool AddTCFRecord(TournamentCategoryFighter tcf);
        ICollection<TournamentCategoryFighter> GetCategoryFighter(int tournamentId);
        public TournamentCategoryFighter GetTCFRecord(int tournamentId, int fighterId);
        ICollection<Fighter> GetFightersInCategoryAndTournament(int tournamentId, int categoryId);
        void UnregisterFighterFromTournament(int tournamentId, int fighterId);
        int CntFighters(int tournamentId);
    }
}