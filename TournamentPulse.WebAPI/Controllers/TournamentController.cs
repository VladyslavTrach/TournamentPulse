using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TournamentPulse.Application.Interface;
using TournamentPulse.Core.Entities;
using TournamentPulse.WebAPI.DTOs.Tournament;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentRepository tournamentRepository, IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tournament>> GetTournaments()
        {
            var tournaments = _tournamentRepository.GetTournaments();
            var tournamentsDTO = _mapper.Map<IEnumerable<ReadTournamentDTO>>(tournaments);

            return Ok(tournamentsDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<Tournament> GetTournamentById(int id)
        {
            var tournament = _tournamentRepository.GetById(id);
            var tournamentDTO = _mapper.Map<ReadTournamentDTO>(tournament);

            if (tournamentDTO == null)
            {
                return NotFound();
            }

            return Ok(tournamentDTO);
        }

        [HttpPost]
        public ActionResult CreateTournament([FromBody] CreateTournamentDTO tournamentdto)
        {
            if (tournamentdto == null)
            {
                return BadRequest("Tournament object is null");
            }

            var tournament = _mapper.Map<Tournament>(tournamentdto);

            try
            {
                bool created = _tournamentRepository.CreateTournament(tournament);

                if (created)
                {
                    return CreatedAtAction(nameof(GetTournamentById), new { id = tournament.Id }, tournament);
                }
                else
                {
                    return BadRequest("Tournament with the same name already exists.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTournament(int id)
        {
            var tournament = _tournamentRepository.GetById(id);

            if (tournament == null)
            {
                return NotFound();
            }

            try
            {
                _tournamentRepository.DeleteTournament(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
