// FighterController.cs
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebAPI.DTOs.Association;
using TournamentPulse.WebAPI.DTOs.Fighter;

namespace TournamentPulse.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class FighterController : ControllerBase
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly IMapper _mapper;

        public FighterController(IFighterRepository fighterRepository, IMapper mapper)
        {
            _fighterRepository = fighterRepository;
            _mapper = mapper;
        }

        // GET api/fighter
        [HttpGet]
        public IActionResult Get()
        {
            var fighters = _fighterRepository.GetAllFighters();
            var fighterDTOs = _mapper.Map<IEnumerable<ReadFighterDTO>>(fighters);
            return Ok(fighterDTOs);
        }

        // GET api/fighter/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var fighter = _fighterRepository.GetFighterById(id);
            var fighterDTO = _mapper.Map<ReadFighterDTO>(fighter);

            if (fighter == null)
            {
                return NotFound();
            }

            return Ok(fighterDTO);
        }

        // POST api/fighter
        [HttpPost]
        public IActionResult Post([FromBody] CreateFighterDTO createFighterDTO)
        {
            try
            {
                var fighter = _mapper.Map<Fighter>(createFighterDTO);

                var isAdded = _fighterRepository.AddFighter(fighter);

                if (isAdded)
                {
                    return CreatedAtAction(nameof(Get), new { id = fighter.Id }, fighter);
                }

                return Conflict("Fighter with the same details already exists.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE api/fighter/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _fighterRepository.DeleteFighter(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
