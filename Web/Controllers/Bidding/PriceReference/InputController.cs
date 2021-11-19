using Domain.Entities.Bidding.PriceReference;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding.PriceReference
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public InputController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<InputController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.InputRepository.GetAll());
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
                return Ok(unitOfWork.InputRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<InputController>
        [HttpPost]
        public IActionResult Post([FromBody] Input input)
        {
            try
            {
                unitOfWork.InputRepository.Add(input);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", input); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<InputController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Input input)
        {
            try
            {
                if (input == null)
                {
                    return BadRequest();
                }

                input.InputId = id;

                unitOfWork.InputRepository.Update(input);
                unitOfWork.SaveChanges();
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
                Input input = unitOfWork.InputRepository
                    .SingleOrDefault(c => c.InputId == id);

                if (input == null)
                {
                    return BadRequest();
                }

                unitOfWork.InputRepository.Remove(input);
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
