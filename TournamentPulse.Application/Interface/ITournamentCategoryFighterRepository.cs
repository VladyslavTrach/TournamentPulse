using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface ITournamentCategoryFighterRepository
    {
        bool AddTCFRecord(TournamentCategoryFighter tcf);
    }
}