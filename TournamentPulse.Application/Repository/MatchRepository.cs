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
        private readonly DataContext _context;

        public MatchRepository(DataContext context)
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
                bool allMatchesAdded = true; // Initialize a flag to track if all matches were added successfully

                foreach (var match in matches)
                {
                    if (!MatchExists(match))
                    {
                        _context.Matches.Add(match);
                    }
                    else
                    {
                        allMatchesAdded = false; // If any match already exists, set the flag to false
                    }
                }

                if (allMatchesAdded)
                {
                    _context.SaveChanges();
                    return true; // All matches were added successfully
                }

                return false; // At least one match already exists or an exception occurred
            }
            catch (Exception ex)
            {
                return false;
            }
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
