using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Repository;
using TournamentPulse.WebUI.Models;
using System;


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
            var tournamentsFromRepository = _tournamentRepository.GetTournaments(); // Retrieve tournaments from your repository

            // Map the entity data to DTO
            var tournamentsViewModel = tournamentsFromRepository.Select(t => new TournamentViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                Location = t.Location,
                Date = t.Date,
                ImageName = t.ImageName ?? "defaultImage.jpg"

            }).ToList();

            return View(tournamentsViewModel);
        }

    }
}
