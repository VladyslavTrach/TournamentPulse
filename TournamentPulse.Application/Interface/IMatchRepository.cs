using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Interface
{
    public interface IMatchRepository
    {
        bool AddMatch(Match match);
        bool AddMatches(ICollection<Match> matches);

        ICollection<Match> GetMatchesForTournament(int tournamentId);
        ICollection<Match> GetOccurredMatchesForCategory(int tournamentId, int categoryId);

        void ArchiveMatchesForCategory(ICollection<Match> matches);
    }
}
