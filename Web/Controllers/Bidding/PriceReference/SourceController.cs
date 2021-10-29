using Domain.Entities.Bidding.PriceReference;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding.PriceReference
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public SourceController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<InputController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.SourceRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<InputController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.SourceRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<InputController>
        [HttpPost]
        public IActionResult Post([FromBody] Source source)
        {
            try
            {
                unitOfWork.SourceRepository.Add(source);
                return Created("api/[controller]", source); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<InputController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Source source)
        {
            try
            {
                if (source == null)
                {
                    return BadRequest();
                }

                source.SourceId = id;

                unitOfWork.SourceRepository.Update(source);
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<InputController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Source source = unitOfWork.SourceRepository
                    .SingleOrDefault(c => c.SourceId == id);

                if (source == null)
                {
                    return BadRequest();
                }

                unitOfWork.SourceRepository.Remove(source);

                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
