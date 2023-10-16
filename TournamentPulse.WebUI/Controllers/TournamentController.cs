using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Tournament;

namespace TournamentPulse.WebUI.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var tournamentsFromDb = _tournamentRepository.GetTournaments();
            var tournaments = _mapper.Map<List<TournamentEventsViewModel>>(tournamentsFromDb);

            return View(tournaments);
        }

        public IActionResult Detail(int id)
        {
            var tournamentFromDB = _tournamentRepository.GetById(id);
            var tournament = _mapper.Map<TournamentDetailsViewModel>(tournamentFromDB);

            return View(tournament);
        }
    }
}
