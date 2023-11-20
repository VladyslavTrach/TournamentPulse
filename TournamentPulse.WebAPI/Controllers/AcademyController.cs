using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebAPI.DTOs.Academy;

namespace TournamentPulse.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademyController : ControllerBase
    {
        private readonly IAcademyRepository _academyRepository;
        private readonly IMapper _mapper;

        public AcademyController(IAcademyRepository academyRepository, IMapper mapper)
        {
            _academyRepository = academyRepository;
            _mapper = mapper;
        }

        // GET api/academy
        [HttpGet]
        public IActionResult Get()
        {
            var academies = _academyRepository.GetAllAcademiesAPI();

            // Create a new list to store the mapped ReadAcademyDTO instances
            var mappedAcademies = new List<ReadAcademyDTO>();

            foreach (Academy academy in academies)
            {
                // Map each Academy to ReadAcademyDTO and add it to the new list
                var mappedAcademy = _mapper.Map<ReadAcademyDTO>(academy);
                mappedAcademies.Add(mappedAcademy);
            }

            // Return the new list containing mapped instances
            return Ok(mappedAcademies);
        }


        // GET api/academy/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var academy = _academyRepository.GetAcademyById(id);

            if (academy == null)
            {
                return NotFound();
            }

            return Ok(academy);
        }

        // POST api/academy
        [HttpPost]
        public IActionResult Post([FromBody] CreateAcademyDTO academyDTO)
        {
            try
            {
                var academy = _mapper.Map<Academy>(academyDTO);
                _academyRepository.AddAcademy(academy);
                return Ok(academy);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Other actions can be added as needed

        // DELETE api/academy/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var academy = _academyRepository.GetAcademyById(id);

            if (academy == null)
            {
                return NotFound();
            }

            _academyRepository.DeleteAcademy(id);

            return Ok(academy);
        }
    }
}
