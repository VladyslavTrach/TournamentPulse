using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebAPI.DTOs.Academy;
using TournamentPulse.WebAPI.DTOs.Association; // Make sure to adjust the namespace based on your DTOs

namespace TournamentPulse.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssociationController : ControllerBase
    {
        private readonly IAssociationRepository _associationRepository;
        private readonly IMapper _mapper;

        public AssociationController(IAssociationRepository associationRepository, IMapper mapper)
        {
            _associationRepository = associationRepository;
            _mapper = mapper;
        }

        // GET api/association
        [HttpGet]
        public IActionResult Get()
        {
            var associations = _associationRepository.GetAllAssociations();

            // Map associations to DTOs
            var associationDTOs = _mapper.Map<IEnumerable<ReadAssociationDTO>>(associations);

            return Ok(associationDTOs);
        }

        // GET api/association/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var association = _associationRepository.GetAssociationById(id);

            if (association == null)
            {
                return NotFound();
            }

            // Map association to DTO
            var associationDTO = _mapper.Map<ReadAssociationDTO>(association);

            return Ok(associationDTO);
        }

        // POST api/association
        [HttpPost]
        public IActionResult Post([FromBody] CreateAssociationDTO createAssociationDTO)
        {
            try
            {
                // Map DTO to entity
                var association = _mapper.Map<Association>(createAssociationDTO);

                _associationRepository.AddAssociation(association);

                // Map the created association back to DTO for response
                var createdAssociationDTO = _mapper.Map<ReadAssociationDTO>(association);

                return CreatedAtAction(nameof(Get), new { id = createdAssociationDTO.id }, createdAssociationDTO);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE api/association/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var association = _associationRepository.GetAssociationById(id);

            if (association == null)
            {
                return NotFound();
            }

            try
            {
                // Delete the association
                _associationRepository.DeleteAssociation(id);

                // Map the deleted association to DTO for response
                var deletedAssociationDTO = _mapper.Map<ReadAssociationDTO>(association);

                return Ok(deletedAssociationDTO);
            }
            catch (Exception ex)
            {
                // Handle exceptions, log them, and return an appropriate error response
                return StatusCode(500, new { error = "An error occurred while deleting the association." });
            }
        }

    }
}
