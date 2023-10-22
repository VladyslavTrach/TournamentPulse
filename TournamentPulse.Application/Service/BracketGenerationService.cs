using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using Match = TournamentPulse.Core.Entities.Match;

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

        public void GenerateMatchesForFirstRound(int tournamentId, int categoryId)
        {
            IList<Fighter> fighters = (IList<Fighter>)_tournamentCategoryFighterRepository.GetFightersInCategoryAndTournament(tournamentId, categoryId);

            List<Match> matches = new List<Match>();

            if (fighters.Count < 2)
            {
                // Handle cases with fewer than 2 fighters.
                // You can add custom logic here as needed.
            }
            else if (fighters.Count == 3)
            {
                // Generate matches for a round-robin format if there are exactly 3 fighters.
                for (int i = 0; i < fighters.Count; i++)
                {
                    for (int j = i + 1; j < fighters.Count; j++)
                    {
                        var match = new Match
                        {
                            Round = 1,
                            TournamentId = tournamentId,
                            CategoryId = categoryId,
                            Fighter1Id = fighters[i].Id,
                            Fighter2Id = fighters[j].Id,
                            MatchStatus = "Scheduled"
                        };
                        matches.Add(match);
                    }
                }
            }
            else
            {
                // Handle cases with non-power-of-two number of fighters.
                // Introduce "bye" matches for some fighters.
                int byes = (fighters.Count % 2 == 0) ? 0 : 1;


                // Generate matches for the first round.
                for (int i = 0; i < fighters.Count - byes; i += 2)
                {
                    var match = new Match
                    {
                        Round = 1,
                        TournamentId = tournamentId,
                        CategoryId = categoryId,
                        Fighter1Id = fighters[i].Id,
                        Fighter2Id = fighters[i + 1].Id,
                        MatchStatus = "Scheduled"
                    };
                    matches.Add(match);
                }

                if(byes != 0)
                {
                    var byeMatch = new Match
                    {
                        Round = 1,
                        Score1 = 0,
                        Score2 = 0,
                        WinningMethod = "No Opponent",
                        TournamentId = tournamentId,
                        CategoryId = categoryId,
                        Fighter1Id = fighters[fighters.Count - 1].Id,
                        Fighter2Id = 7,
                        WinnerId = fighters[fighters.Count - 1].Id,
                        MatchStatus = "Occurred"
                    };
                    matches.Add(byeMatch);
                }
            }

            _matchRepository.AddMatches(matches);
        }


        public void GenerateMatchesForNextRound(int tournamentId, int categoryId)
        {
            // Get the matches from the previous round.
            List<Match> previousRoundMatches = (List<Match>)_matchRepository.GetOccurredMatchesForCategory(tournamentId, categoryId);
            int byes = (previousRoundMatches.Count % 2 == 0) ? 0 : 1;

            _matchRepository.ArchiveMatchesForCategory(previousRoundMatches);



            // Create a list to store the matches for the next round.
            List<Match> nextRoundMatches = new List<Match>();

            // Logic to determine winners and generate matches for the next round.
            for (int i = 0; i < previousRoundMatches.Count - byes; i += 2)
            {
                var match = new Match
                {
                    Round = previousRoundMatches[i].Round + 1,
                    TournamentId = tournamentId,
                    CategoryId = categoryId,
                    Fighter1Id = (int)previousRoundMatches[i].WinnerId,
                    Fighter2Id = (int)previousRoundMatches[i + 1].WinnerId,
                    MatchStatus = "Scheduled"
                };
                nextRoundMatches.Add(match);
            }

            if (byes != 0)
            {
                var byeMatch = new Match
                {
                    Round = previousRoundMatches[(previousRoundMatches.Count - 1)].Round + 1,
                    Score1 = 0,
                    Score2 = 0,
                    WinningMethod = "No Opponent",
                    TournamentId = tournamentId,
                    CategoryId = categoryId,
                    Fighter1Id = (int)previousRoundMatches[(previousRoundMatches.Count - 1)].WinnerId,
                    Fighter2Id = 7,
                    WinnerId = (int)previousRoundMatches[(previousRoundMatches.Count - 1)].WinnerId,
                    MatchStatus = "Occurred"
                };
                nextRoundMatches.Add(byeMatch);
            }

            _matchRepository.AddMatches(nextRoundMatches);

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
