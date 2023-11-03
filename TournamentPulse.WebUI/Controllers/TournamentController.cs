using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Service;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.CategoryFighter;
using TournamentPulse.WebUI.Models.Fighter;
using TournamentPulse.WebUI.Models.Match;
using TournamentPulse.WebUI.Models.Tournament;

namespace TournamentPulse.WebUI.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IFighterRepository _fighterRepository;
        private readonly IMapper _mapper;
        private readonly ITournamentRegistrationService _tournamentRegistrationService;
        private readonly IBracketGenerationService _bracketGenerationService;

        public TournamentController(
            ITournamentRepository tournamentRepository,
            IMatchRepository matchRepository,
            IFighterRepository fighterRepository,
            IMapper mapper,
            ITournamentRegistrationService tournamentRegistrationService,
            IBracketGenerationService bracketGenerationService)
        {
            _tournamentRepository = tournamentRepository;
            _matchRepository = matchRepository;
            _fighterRepository = fighterRepository;
            _mapper = mapper;
            _tournamentRegistrationService = tournamentRegistrationService;
            _bracketGenerationService = bracketGenerationService;
        }

        public IActionResult Index()
        {
            var tournamentsFromDb = _tournamentRepository.GetTournaments();
            var tournaments = _mapper.Map<List<TournamentEventsViewModel>>(tournamentsFromDb);

            return View(tournaments);
        }

        public IActionResult Detail(int id)
        {
            var tournamentFromDb = _tournamentRepository.GetById(id);
            var tournament = _mapper.Map<TournamentDetailsViewModel>(tournamentFromDb);

            ViewData["TournamentId"] = id;
            return View(tournament);
        }

        public IActionResult Category(int id)
        {
            var categoryFightersFromDb = _tournamentRegistrationService.GetCategoryFighter(id);
            var categoryFighterGroups = categoryFightersFromDb
                .GroupBy(tc => tc.CategoryId)
               .Select(group => new CategoryFighterListViewModel
               {
                   Category = group.First().Category?.Name ?? "Unknown",
                   Fighters = group.Select(tc => new FighterListViewModel
                   {
                       Id = tc.Fighter.Id,
                       FullName = tc.Fighter.FullName ?? "Unknown",
                       Age = tc.Fighter.Age,
                       Weight = tc.Fighter.Weight,
                       Rank = tc.Fighter.Rank ?? "Unknown",
                       Academy = tc.Fighter.Academy?.Name ?? "Unknown"
                   }).ToList()
               })
                .ToList();

            ViewData["TournamentId"] = id;
            return View(categoryFighterGroups);
        }

        public IActionResult Bracket(int id)
        {
            var matchesFromDb = _matchRepository.GetMatchesForTournament(id);

            var matches = matchesFromDb
                .GroupBy(tc => tc.CategoryId)
                .Select(group => new CategoryMatchListViewModel
                {
                    Category = group.First().Category.Name,
                    Matches = group.Select(cm => _mapper.Map<MatchViewModel>(cm)).ToList(),
                    TotalRounds = CountTotalRounds(CountTotalFighters(group.ToList()))
                })
                .ToList();

            ViewData["TournamentId"] = id;
            return View(matches);
        }

        public IActionResult GenerateFirstRoundBracket(int tournamentId, string categoryName)
        {
            _bracketGenerationService.GenerateMatchesForFirstRound(tournamentId, categoryName);

            return RedirectToAction("Bracket", new { id = tournamentId });
        }

        public IActionResult GenerateNextRoundBracket(int tournamentId, string categoryName)
        {
            _bracketGenerationService.GenerateMatchesForNextRound(tournamentId, categoryName);

            return RedirectToAction("Bracket", new { id = tournamentId });
        }

        public IActionResult EditMatch(int matchId)
        {
            var match = _mapper.Map<MatchViewModel>(_matchRepository.GetMatchById(matchId));
            return View(match);
        }

        [HttpPost]
        public IActionResult EditMatch(MatchViewModel match)
        {
            if (ModelState.IsValid)
            {
                var matchEntity = new Match
                {
                    Id = match.Id,
                    Round = match.Round,
                    Score1 = match.Score1,
                    Score2 = match.Score2,
                    MatchStatus = match.MatchStatus,
                    WinningMethod = match.WinningMethod,
                    TournamentId = match.TournamentId,
                    CategoryId = match.CategoryId,
                    Fighter1Id = _fighterRepository.GetFighterIdByFullName(match.Fighter1),
                    Fighter2Id = _fighterRepository.GetFighterIdByFullName(match.Fighter2),
                    WinnerId = _fighterRepository.GetFighterIdByFullName(match.Winner),
                };

                // Update the match using _matchRepository
                _matchRepository.UpdateMatch(matchEntity);

                // Redirect to a page or action that shows the updated match details
                return RedirectToAction("Bracket", new { id = match.TournamentId });
            }

            // If the model state is not valid, return to the edit form with validation errors
            return View(match);
        }



        //[Authorize(Roles = "User")]
        public IActionResult Register(int Id)
        {
            //_bracketGenerationService.GenerateMatchesForFirstRound(Id, 8);
            //_bracketGenerationService.GenerateMatchesForNextRound(Id, 8);

            //_tournamentRegistrationService.RegisterFighterForTournament(Id, 16);
            //_tournamentRegistrationService.UnregisterFighterFromTournament(Id, 1); //Unregister

            return RedirectToAction("Detail", new { id = Id });
        }

        [Authorize(Roles = "Admin,Organizer")]
        public IActionResult Add()
        {
            return View();
        }



        //-----------------------------------------//

        private int CountTotalRounds(int fightersCnt)
        {
            if (fightersCnt < 2)
            {
                return 0;
            }

            int closestPowerOf2 = (int)Math.Pow(2, (int)Math.Log(fightersCnt, 2));
            int totalRounds = (int)Math.Log(closestPowerOf2, 2);
            return totalRounds;
        }

        private int CountTotalFighters(List<Match> matches)
        {
            HashSet<int> uniqueFighters = new HashSet<int>();

            foreach (Match match in matches)
            {
                if (match.Fighter2Id != 7)
                {
                    uniqueFighters.Add(match.Fighter1Id);
                    uniqueFighters.Add(match.Fighter2Id);
                }
            }

            return uniqueFighters.Count;
        }

    }
}