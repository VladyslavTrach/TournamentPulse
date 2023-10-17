using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Service;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.CategoryFighter;
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

            //Need To Fix
            //var categoryFighters = _mapper.Map<CategoryFighterListViewModel>(categoryFightersFromDb);

            var tournamentAndcategoryFighters = new TournamentDetailsPageViewModel
            {
                tournamentDetailsViewModel = tournament,
                categoryFighterListViewModel = categoryFightersFromDb
            };

            return View(tournamentAndcategoryFighters);
        }

        public IActionResult Register(int Id)
        {
            _tournamentRegistrationService.RegisterFighterForTournament(Id, 2);

            return View("Detail");
        }
    }
}
