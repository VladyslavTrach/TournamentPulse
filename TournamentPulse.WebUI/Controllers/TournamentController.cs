using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Repository;
using System;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Tournament;

namespace TournamentPulse.WebUI.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentController(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public IActionResult Index()
        {
            var tournamentFromDb = _tournamentRepository.GetTournaments();
            var tournaments = TournamentMapper(tournamentFromDb);

            return View(tournaments);
        }

        public IActionResult Detail(int id)
        {
            var tournamentFromDB = _tournamentRepository.GetById(id);
            var tournament = TournamentDetailsMapper(tournamentFromDB);

            return View(tournament);
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                 _tournamentRepository.CreateTournament(tournament);

                return RedirectToAction("Index");
            }

            // If the model state is not valid, return the view with validation errors
            return View(tournament);
        }


        public TournamentDetailsViewModel TournamentDetailsMapper(Tournament tournament)
        {
            return new TournamentDetailsViewModel
            {
                Id = tournament.Id,
                Name = tournament.Name,
                Description = tournament.Description,
                Country = tournament.Country,
                City = tournament.City,
                Date = tournament.Date,
                ImageName = tournament.ImageName ?? "https://evolve-mma.com/wp-content/uploads/2022/09/gordon-ryan.jpg",
                MaxParticipants = tournament.MaxParticipants,
                CreditCard = tournament.CreditCard ?? "Not Provided",
                Email = tournament.Email,
                Phone = tournament.Phone ?? "Not Provided",
                Price = tournament.Price
            };
        }
        public List<TournamentEventsViewModel> TournamentMapper(IEnumerable<Tournament> tournaments)
        {
            return tournaments.Select(t => new TournamentEventsViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Country = t.Country,
                City = t.City,
                Date = t.Date,
                ImageName = t.ImageName ?? "https://evolve-mma.com/wp-content/uploads/2022/09/gordon-ryan.jpg",
            }).ToList();
        }
    }

}
