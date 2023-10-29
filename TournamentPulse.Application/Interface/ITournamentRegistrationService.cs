using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface ITournamentRegistrationService
    {
        void RegisterFighterForTournament(int tournamentId, int fighterId);
        void UnregisterFighterFromTournament(int tournamentId, int fighterId);
        ICollection<TournamentCategoryFighter> GetCategoryFighter(int tournamentId);
    }
}
