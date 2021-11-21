using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditiveLevelController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AdditiveLevelController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<AdditiveLevelController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.AdditiveLevelRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AdditiveLevelController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.AdditiveLevelRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AdditiveLevelController>
        [HttpPost]
        public IActionResult Post([FromBody] AdditiveLevel AdditiveLevel)
        {
            try
            {
                Console.WriteLine("Enviando para a unity of work.");
                unitOfWork.AdditiveLevelRepository.Add(AdditiveLevel);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", AdditiveLevel); // 201
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
                return Ok(unitOfWork.AdditiveLevelRepository.Find(c => c.ContractId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AdditiveLevelController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AdditiveLevel AdditiveLevel)
        {
            try
            {
                if (AdditiveLevel == null)
                {
                    return BadRequest();
                }

                AdditiveLevel.AdditiveLevelId = id;

                unitOfWork.AdditiveLevelRepository.Update(AdditiveLevel);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AdditiveLevelController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                AdditiveLevel AdditiveLevel = unitOfWork.AdditiveLevelRepository.SingleOrDefault(c => c.AdditiveLevelId == id);

                if (AdditiveLevel == null)
                {
                    return BadRequest();
                }

                unitOfWork.AdditiveLevelRepository.Remove(AdditiveLevel);
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
