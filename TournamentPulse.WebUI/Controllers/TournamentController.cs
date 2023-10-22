using AutoMapper;
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
        private readonly TournamentRegistrationService _tournamentRegistrationService;
        private readonly BracketGenerationService _bracketGenerationService;

        public TournamentController(
            ITournamentRepository tournamentRepository,
            IMatchRepository matchRepository,
            IFighterRepository fighterRepository,
            IMapper mapper, 
            TournamentRegistrationService tournamentRegistrationService,
            BracketGenerationService bracketGenerationService)
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

            // Use AutoMapper to map the entities to view models within your LINQ query
            var matches = matchesFromDb
                .GroupBy(tc => tc.CategoryId)
                .Select(group => new CategoryMatchListViewModel
                {
                    Category = group.First().Category.Name,
                    Matches = group.Select(cm => _mapper.Map<MatchViewModel>(cm)).ToList()
                })
                .ToList();

            ViewData["TournamentId"] = id;
            return View(matches);
        }



        public IActionResult Register(int Id)
        {
            _bracketGenerationService.GenerateMatchesForCategory(Id, 8);
            //_tournamentRegistrationService.RegisterFighterForTournament(Id, 12);
            //_tournamentRegistrationService.UnregisterFighterFromTournament(Id, 1); //Unregister

            return RedirectToAction("Detail", new { id = Id });
        }

    }
}
