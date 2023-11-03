using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TournamentPulse.Core.Entities;
using Match = TournamentPulse.Core.Entities.Match;

namespace TournamentPulse.Application.Interface
{
    public interface IMatchRepository
    {
        bool AddMatch(Match match);
        bool AddMatches(ICollection<Match> matches);

        ICollection<Match> GetMatchesForTournament(int tournamentId);
        ICollection<Match> GetOccurredMatchesForCategory(int tournamentId, int categoryId);

        int ArchiveMatchesForCategory(ICollection<Match> matches);

        Match GetMatchById(int id);

        void UpdateMatch(Match match);
    }
}
