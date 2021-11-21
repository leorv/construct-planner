using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditiveClauseController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AdditiveClauseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<AdditiveClauseController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.AdditiveClauseRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AdditiveClauseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.AdditiveClauseRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AdditiveClauseController>
        [HttpPost]
        public IActionResult Post([FromBody] AdditiveClause AdditiveClause)
        {
            try
            {
                Console.WriteLine("Enviando para a unity of work.");
                unitOfWork.AdditiveClauseRepository.Add(AdditiveClause);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", AdditiveClause); // 201
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
                return Ok(unitOfWork.AdditiveClauseRepository.Find(c => c.ContractId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AdditiveClauseController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AdditiveClause AdditiveClause)
        {
            try
            {
                if (AdditiveClause == null)
                {
                    return BadRequest();
                }

                AdditiveClause.AdditiveClauseId = id;

                unitOfWork.AdditiveClauseRepository.Update(AdditiveClause);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AdditiveClauseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                AdditiveClause AdditiveClause = unitOfWork.AdditiveClauseRepository.SingleOrDefault(c => c.AdditiveClauseId == id);

                if (AdditiveClause == null)
                {
                    return BadRequest();
                }

                unitOfWork.AdditiveClauseRepository.Remove(AdditiveClause);
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
