using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Repository;
using TournamentPulse.WebUI.Models;
using System;
using TournamentPulse.Core.Entities;

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
            var tournaments = TournamentMapper(_tournamentRepository.GetTournaments());

            return View(tournaments);
        }

        public IActionResult Detail(int id)
        {
            var tournamentFromDB = _tournamentRepository.GetById(id);
            var tournament = TournamentMapper(tournamentFromDB);

            return View(tournament);
        }

        public TournamentViewModel TournamentMapper(Tournament tournament)
        {
            return new TournamentViewModel
            {
                Id = tournament.Id,
                Name = tournament.Name,
                Description = tournament.Description,
                Country = tournament.Country,
                City = tournament.City,
                Date = tournament.Date,
                ImageName = tournament.ImageName ?? "https://evolve-mma.com/wp-content/uploads/2022/09/gordon-ryan.jpg",
                MaxParticipants = tournament.MaxParticipants,
                Email = tournament.Email,
                Phone = tournament.Phone ?? "Not Provided"
            };
        }
        public List<TournamentViewModel> TournamentMapper(IEnumerable<Tournament> tournaments)
        {
            return tournaments.Select(t => new TournamentViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Country = t.Country,
                City = t.City,
                Date = t.Date,
                ImageName = t.ImageName ?? "https://evolve-mma.com/wp-content/uploads/2022/09/gordon-ryan.jpg",
                MaxParticipants = t.MaxParticipants,
                Email = t.Email,
                Phone = t.Phone ?? "Not Provided"
            }).ToList();
        }
    }

}
