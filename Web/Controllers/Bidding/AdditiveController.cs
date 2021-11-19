using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditiveController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        public AdditiveController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }



        // GET: api/<AdditiveController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.AdditiveRepository.GetAll());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AdditiveController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.AdditiveRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AdditiveController>
        [HttpPost]
        public IActionResult Post([FromBody] Additive additive)
        {
            try
            {
                unitOfWork.AdditiveRepository.Add(additive);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", additive); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<AdditiveController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Additive additive)
        {
            try
            {
                if (additive == null)
                {
                    return BadRequest();
                }

                additive.ContractId = id;

                unitOfWork.AdditiveRepository.Update(additive);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AdditiveController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Additive additive = unitOfWork.AdditiveRepository.SingleOrDefault(c => c.AdditiveId == id);

                if (additive == null)
                {
                    return BadRequest();
                }

                unitOfWork.AdditiveRepository.Remove(additive);
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
