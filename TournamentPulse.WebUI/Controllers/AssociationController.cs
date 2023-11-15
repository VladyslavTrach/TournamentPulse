using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.WebUI.Models.Association;
using AutoMapper;
using System.Collections.Generic;
using TournamentPulse.Application.Repository;
using TournamentPulse.WebUI.Models.Academy;
using TournamentPulse.WebUI.Models.Fighter;
using Microsoft.AspNetCore.Authorization;
using TournamentPulse.Core.Entities;

namespace TournamentPulse.WebUI.Controllers
{
    public class AssociationController : Controller
    {
        private readonly IAssociationRepository _associationRepository;
        private readonly IAcademyRepository _academyRepository;
        private readonly IMapper _mapper;

        public AssociationController(IAssociationRepository associationRepository, IAcademyRepository academyRepository, IMapper mapper)
        {
            _associationRepository = associationRepository;
            _academyRepository = academyRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var associationsFromDb = _associationRepository.GetAllAssociations();
            var associations = _mapper.Map<List<AssociationListViewModel>>(associationsFromDb);

            return View(associations);
        }

        public IActionResult Detail(string associationName)
        {
            var associationFromDb = _associationRepository.GetAssociationByName(associationName);
            var academiesFromDb = _academyRepository.GetAcademiesByAssociation(associationFromDb.Id);

            AssociationDetailsListViewModel association = _mapper.Map<AssociationDetailsListViewModel>(associationFromDb);

            List<AcademyListViewModel> academies = academiesFromDb.Select(academy => _mapper.Map<AcademyListViewModel>(academy)).ToList();

            association.Academies = academies;

            return View(association);
        }

        [Authorize(Roles = "Admin,Organizer")]
        public IActionResult Add()
        {

            return View();
        }

        [Authorize(Roles = "Admin,Organizer")]
        [HttpPost]
        public IActionResult Add(AssociationViewModel model)
        {
            if (ModelState.IsValid)
            {
                Association association = new Association();
                association.Name = model.Name;
                

                _associationRepository.AddAssociation(association);

                return RedirectToAction("Index");
            }


            // If the model is not valid, redisplay the form with validation errors
            return View(model);
        }
    }
}
