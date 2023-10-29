using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface IBracketGenerationService
    {
        void GenerateMatchesForFirstRound(int tournamentId, int categoryId);
        void GenerateMatchesForNextRound(int tournamentId, int categoryId);
        List<Fighter> GetFightersFromMatches(ICollection<Match> matches);
    }
}
