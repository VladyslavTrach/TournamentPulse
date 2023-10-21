using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.Application.Service
{
    public class BracketGenerationService
    {
        private readonly ITournamentCategoryFighterRepository _tournamentCategoryFighterRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IFighterRepository _fighterRepository;

        public BracketGenerationService(
            ITournamentCategoryFighterRepository tournamentCategoryFighterRepository, 
            IMatchRepository matchRepository,
            IFighterRepository fighterRepository)
        {
            _tournamentCategoryFighterRepository = tournamentCategoryFighterRepository;
            _matchRepository = matchRepository;
            _fighterRepository = fighterRepository;
        }

        public bool GenerateMatchesForCategory(int tournamentId, int categoryId)
        {
            IList<Fighter> fighters = (IList<Fighter>)_tournamentCategoryFighterRepository.GetFightersInCategoryAndTournament(tournamentId, categoryId);

            if (fighters.Count < 2)
            {
                // There are not enough fighters for matches
                return false;
            }

            List<Match> matches = new List<Match>();

            for (int i = 0; i < fighters.Count/2; i++)
            {
                var match = new Match
                {
                    TournamentId = tournamentId,
                    CategoryId = categoryId,
                    Fighter1Id = fighters[i].Id,
                    Fighter2Id = fighters[i + 1].Id,
                    MatchStatus = "Scheduled" // You can set the default status here
                };
                matches.Add(match);
            }

            _matchRepository.AddMatches(matches);

            return true;
        }
        public List<Fighter> GetFightersFromMatches(ICollection<Match> matches) 
        { 
            var fighters = new List<Fighter>();
            foreach (var match in matches)
            {
                fighters.Add(_fighterRepository.GetFighterById(match.Fighter1Id));
                fighters.Add(_fighterRepository.GetFighterById(match.Fighter2Id));
            }
            return fighters;
        }
    }
}
