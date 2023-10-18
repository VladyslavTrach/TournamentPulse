using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Service;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.CategoryFighter;
using TournamentPulse.WebUI.Models.Fighter;
using TournamentPulse.WebUI.Models.Tournament;

namespace TournamentPulse.WebUI.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;
        private readonly TournamentRegistrationService _tournamentRegistrationService;

        public TournamentController(ITournamentRepository tournamentRepository, IMapper mapper, TournamentRegistrationService tournamentRegistrationService)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
            _tournamentRegistrationService = tournamentRegistrationService;
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


            var tournamentAndcategoryFighters = new TournamentDetailsPageViewModel
            {
                tournamentDetailsViewModel = tournament,
                categoryFighterListViewModel = categoryFighterGroups
            };

            return View(tournamentAndcategoryFighters);
        }




        public IActionResult Register(int Id)
        {
            _tournamentRegistrationService.RegisterFighterForTournament(Id, 4);

            return View("Detail");
        }

       

    }
}
