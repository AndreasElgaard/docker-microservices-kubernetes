﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Repository;
using API.Models;
using Microsoft.AspNetCore.Http;
using API.Controllers.Requests;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HaandvaerkerController : ControllerBase
    {
        private readonly IHaandVaerkerRepository _repository;
        private readonly IMapper _mapper;

        public HaandvaerkerController(IHaandVaerkerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<HaandvaerkerController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Haandvaerker>>> Get()
        {
            var result = await _repository.GetAll();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET api/<HaandvaerkerController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Haandvaerker>> GetById(int id)
        {
            var result = await _repository.GetById(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        // POST api/<HaandvaerkerController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post([FromBody] HaandVaerkerRequest haandvaerkerRequest)
        {


            //var model = _mapper.Map<Haandvaerker>(haandvaerkerRequest);
            var model = new Haandvaerker
            {
                HVAnsaettelsedato = haandvaerkerRequest.HVAnsaettelsedato,
                HVEfternavn = haandvaerkerRequest.HVEfternavn,
                HVFagomraade = haandvaerkerRequest.HVFagomraade,
                HVFornavn = haandvaerkerRequest.HVFornavn
            };
            try
            {
                await _repository.Add(model);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();

        }

        // PUT api/<HaandvaerkerController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Put([FromBody] HaandVaerkerRequest haandvaerkerRequest)
        {

            var model = _mapper.Map<Haandvaerker>(haandvaerkerRequest);

            try
            {
                await _repository.Update(model);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/<HaandvaerkerController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repository.Remove(id);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
