using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Repository;
using TournamentPulse.Core.Entities;
using TournamentPulse.Core.Enums;
using Match = TournamentPulse.Core.Entities.Match;

namespace TournamentPulse.Application.Service
{
    public class BracketGenerationService : IBracketGenerationService
    {
        private readonly ITournamentCategoryFighterRepository _tournamentCategoryFighterRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IFighterRepository _fighterRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BracketGenerationService(
            ITournamentCategoryFighterRepository tournamentCategoryFighterRepository, 
            IMatchRepository matchRepository,
            IFighterRepository fighterRepository,
            ICategoryRepository categoryRepository)
        {
            _tournamentCategoryFighterRepository = tournamentCategoryFighterRepository;
            _matchRepository = matchRepository;
            _fighterRepository = fighterRepository;
            _categoryRepository = categoryRepository;
        }

        public void GenerateMatchesForFirstRound(int tournamentId, string categoryName)
        {
            int categoryId = _categoryRepository.GetCategoryId(categoryName);
            IList<Fighter> fighters = (IList<Fighter>)_tournamentCategoryFighterRepository.GetFightersInCategoryAndTournament(tournamentId, categoryId);

            List<Match> matches = new List<Match>();

            if (fighters.Count < 2)
            {
                return;
            }
            else if (fighters.Count == 3)
            {
                matches = GenerateRoundRobinMatches(tournamentId, categoryId, fighters);
            }
            else
            {
                matches = GenerateFirstRoundMatches(tournamentId, categoryId, fighters);
            }


            _matchRepository.AddMatches(matches);
        }


        public void GenerateMatchesForNextRound(int tournamentId, string categoryName)
        {
            int categoryId = _categoryRepository.GetCategoryId(categoryName);
            _matchRepository.AddMatches(GenerateNextRoundMatches(tournamentId, categoryId));
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

        private List<Match> GenerateRoundRobinMatches(int tournamentId, int categoryId, IList<Fighter> fighters)
        {
            List<Match> matches = new List<Match>();

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
                        MatchStatus = MatchStatusEnum.Scheduled.ToString(),
                    };
                    matches.Add(match);
                }
            }
            return matches;
        }
        private List<Match> GenerateFirstRoundMatches(int tournamentId, int categoryId, IList<Fighter> fighters)
        {
            List<Match> matches = new List<Match>();

            int byes = (fighters.Count % 2 == 0) ? 0 : 1;

            if (byes != 0)
            {
                Random random = new Random();
                int byeFighterIndex = random.Next(0, fighters.Count - 1);
                var byeMatch = new Match
                {
                    Round = 1,
                    Score1 = 0,
                    Score2 = 0,
                    WinningMethod = WinningMethodEnum.NoOpponent.ToString(),
                    TournamentId = tournamentId,
                    CategoryId = categoryId,
                    Fighter1Id = fighters[byeFighterIndex].Id,
                    Fighter2Id = 7,
                    WinnerId = fighters[byeFighterIndex].Id,
                    MatchStatus = MatchStatusEnum.Occurred.ToString(),
                };
                matches.Add(byeMatch);
                fighters.Remove(fighters[byeFighterIndex]);
            }

            // Generate matches for the first round.
            for (int i = 0; i < fighters.Count; i += 2)
            {
                var match = new Match
                {
                    Round = 1,
                    TournamentId = tournamentId,
                    CategoryId = categoryId,
                    Fighter1Id = fighters[i].Id,
                    Fighter2Id = fighters[i + 1].Id,
                    MatchStatus = MatchStatusEnum.Scheduled.ToString(),
                };
                matches.Add(match);
            }

            return matches;
        }
        private List<Match> GenerateNextRoundMatches(int tournamentId, int categoryId)
        {
            List<Match> previousRoundMatches = (List<Match>)_matchRepository.GetNotArchivedMatchesForCategory(tournamentId, categoryId);

            IList<Fighter> fighters = (IList<Fighter>)_tournamentCategoryFighterRepository.GetFightersInCategoryAndTournament(tournamentId, categoryId);

            if (fighters.Count == previousRoundMatches.Count)
            {
                _matchRepository.ArchiveMatchesForCategory(previousRoundMatches);
                return new List<Match>();
            }

            if (!CheckIfAllMatchesOccured(previousRoundMatches)) 
            { 
                return new List<Match>();
            }
            else if (previousRoundMatches.Count <= 1)
            {
                _matchRepository.ArchiveMatchesForCategory(previousRoundMatches);
                return new List<Match>();
            }
            int byes = (previousRoundMatches.Count % 2 == 0) ? 0 : 1;

            int ByeMatchWinnerId = _matchRepository.ArchiveMatchesForCategory(previousRoundMatches);

            List<Match> nextRoundMatches = new List<Match>();

            if (byes != 0)
            {
                Random random = new Random();
                int byeFighterIndex = random.Next(0, previousRoundMatches.Count - 1);

                //Cycle for the same fighter to not get into byeMatch twice in a row
                while (ByeMatchWinnerId == previousRoundMatches[(byeFighterIndex)].WinnerId)
                    byeFighterIndex = random.Next(0, previousRoundMatches.Count - 1);

                var byeMatch = new Match
                {
                    Round = previousRoundMatches[(previousRoundMatches.Count - 1)].Round + 1,
                    Score1 = 0,
                    Score2 = 0,
                    WinningMethod = WinningMethodEnum.NoOpponent.ToString(),
                    TournamentId = tournamentId,
                    CategoryId = categoryId,
                    Fighter1Id = (int)previousRoundMatches[(byeFighterIndex)].WinnerId,
                    Fighter2Id = 7,
                    WinnerId = (int)previousRoundMatches[(byeFighterIndex)].WinnerId,
                    MatchStatus = MatchStatusEnum.Occurred.ToString()
                };

                previousRoundMatches.Remove(previousRoundMatches[byeFighterIndex]);
                nextRoundMatches.Add(byeMatch);
            }

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
                    MatchStatus = MatchStatusEnum.Scheduled.ToString()
                };
                nextRoundMatches.Add(match);
            }

            return nextRoundMatches;
        }
        private bool CheckIfAllMatchesOccured(List<Match> matches)
        {
            foreach (Match match in matches)
            {
                if (!(match.MatchStatus == MatchStatusEnum.Occurred.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
