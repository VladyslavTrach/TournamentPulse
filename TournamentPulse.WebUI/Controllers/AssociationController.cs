using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.WebUI.Models.Association;
using AutoMapper;
using System.Collections.Generic;

namespace TournamentPulse.WebUI.Controllers
{
    public class AssociationController : Controller
    {
        private readonly IAssociationRepository _associationRepository;
        private readonly IMapper _mapper;

        public AssociationController(IAssociationRepository associationRepository, IMapper mapper)
        {
            _associationRepository = associationRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var associationsFromDb = _associationRepository.GetAllAssociations();
            var associations = _mapper.Map<List<AssociationListViewModel>>(associationsFromDb);

            return View(associations);
        }
    }
}
