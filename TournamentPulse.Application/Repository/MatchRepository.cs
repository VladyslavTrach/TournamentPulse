using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.Infrastructure.Data;
using Match = TournamentPulse.Core.Entities.Match;

namespace TournamentPulse.Application.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDataContext _context;

        public MatchRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public bool AddMatch(Match match)
        {
            try
            {
                if (!MatchExists(match))
                {
                    _context.Matches.Add(match);
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddMatches(ICollection<Match> matches)
        {
            try
            {
                // Materialize the existing matches as a list
                var existingMatches = _context.Matches.ToList();

                // Perform the necessary comparison client-side to find new matches
                var newMatches = matches.Where(match =>
                    !existingMatches.Any(existingMatch =>
                        existingMatch.Fighter1Id == match.Fighter1Id &&
                        existingMatch.Fighter2Id == match.Fighter2Id &&
                        existingMatch.Round == match.Round &&
                        existingMatch.TournamentId == match.TournamentId
                    )
                ).ToList();

                if (newMatches.Any())
                {
                    _context.Matches.AddRange(newMatches);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public int ArchiveMatchesForCategory(ICollection<Match> matches)
        {
            int noOpponentWinnerId = 0;

            foreach (var match in matches)
            {
                if (match.MatchStatus == "Occurred" && match.Score1 != null && match.Score2 != null && match.WinningMethod != null)
                {
                    match.MatchStatus = "Archived";
                    _context.Matches.Update(match);
                }

                

                if (match.WinningMethod == "No Opponent")
                {
                    noOpponentWinnerId = (int)match.WinnerId;
                }
            }

            //var noOpponentMatchesToRemove = _context.Matches.Where(m => m.WinningMethod == "No Opponent");
            //_context.Matches.RemoveRange(noOpponentMatchesToRemove);

            _context.SaveChanges();

            return noOpponentWinnerId;
        }


        public ICollection<Match> GetOccurredMatchesForCategory(int tournamentId, int categoryId)
        {
            return _context.Matches
                .Include(m => m.Category)
                .Include(m => m.Fighter1)
                .Include(m => m.Fighter2)
                .Where(m => m.TournamentId == tournamentId && m.CategoryId == categoryId && m.MatchStatus == "Occurred").ToList();
        }

        public ICollection<Match> GetMatchesForTournament(int tournamentId)
        {
            return _context.Matches
                .Include(m => m.Category)
                .Include(m => m.Fighter1)
                .Include(m => m.Fighter2)
                .Where(m => m.TournamentId == tournamentId).ToList();
        }


        public bool MatchExists(Match match)
        {
            var existingMatch = _context.Matches.FirstOrDefault(m => m.Fighter1Id == match.Fighter1Id && m.Fighter2Id == match.Fighter2Id && m.TournamentId == match.TournamentId && m.CategoryId == match.CategoryId);

            return existingMatch != null;
        }
    }
}
