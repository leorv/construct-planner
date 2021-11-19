using Domain.Entities.Bidding.PriceReference;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding.PriceReference
{
    [Route("api/[controller]")]
    [ApiController]
    public class BDIController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public BDIController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<BDIController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.BDIRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<BDIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.BDIRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<BDIController>
        [HttpPost]
        public IActionResult Post([FromBody] BDI bdi)
        {
            try
            {
                unitOfWork.BDIRepository.Add(bdi);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", bdi); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<BDIController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] BDI bdi)
        {
            try
            {
                if (bdi == null)
                {
                    return BadRequest();
                }

                bdi.BDIId = id;

                unitOfWork.BDIRepository.Update(bdi);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<BDIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                BDI bdi = unitOfWork.BDIRepository
                    .SingleOrDefault(c => c.BDIId == id);

                if (bdi == null)
                {
                    return BadRequest();
                }

                unitOfWork.BDIRepository.Remove(bdi);
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
