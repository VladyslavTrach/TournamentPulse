using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Application.Repository;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebUI.Models.Fighter;

namespace TournamentPulse.WebUI.Controllers
{
    public class FighterController : Controller
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly IAcademyRepository _academyRepository;

        public FighterController(IFighterRepository fighterRepository, IAcademyRepository academyRepository)
        {
            _fighterRepository = fighterRepository;
            _academyRepository = academyRepository;
        }
        public IActionResult Index()
        {
            var fightersFromDb = _fighterRepository.GetAllFighters();
            var fighters = FighterListMapper(fightersFromDb);

            return View(fighters);
        }

        public List<FighterListViewModel> FighterListMapper(IEnumerable<Fighter> fighters)
        {
            return fighters.Select(fighter => new FighterListViewModel
            {
                Id = fighter.Id,
                FullName = fighter.FullName,
                Age = fighter.Age,
                Weight = fighter.Weight,
                Rank = fighter.Rank,
                Academy = _academyRepository.GetAcademyById(fighter.AcademyId).Name
            }).ToList();
        }
    }
}
