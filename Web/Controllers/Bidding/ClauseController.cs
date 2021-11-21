using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClauseController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ClauseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<ClauseController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.ClauseRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ClauseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.ClauseRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ClauseController>
        [HttpPost]
        public IActionResult Post([FromBody] Clause clause)
        {
            try
            {
                Console.WriteLine("Enviando para a unity of work.");
                unitOfWork.ClauseRepository.Add(clause);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", clause); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll([FromBody] int id)
        {
            try
            {
                return Ok(unitOfWork.ClauseRepository.Find(c => c.ContractId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClauseController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Clause clause)
        {
            try
            {
                if (clause == null)
                {
                    return BadRequest();
                }

                clause.ClauseId = id;

                unitOfWork.ClauseRepository.Update(clause);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClauseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Clause clause = unitOfWork.ClauseRepository.SingleOrDefault(c => c.ClauseId == id);

                if (clause == null)
                {
                    return BadRequest();
                }

                unitOfWork.ClauseRepository.Remove(clause);
                unitOfWork.SaveChanges();

                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
