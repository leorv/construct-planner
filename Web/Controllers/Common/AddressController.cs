using Domain.Entities.Common;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AddressController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<SourceItemController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.AddressRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SourceItemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.AddressRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SourceItemController>
        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            try
            {
                unitOfWork.AddressRepository.Add(address);
                return Created("api/[controller]", address); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<SourceItemController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Address address)
        {
            try
            {
                if (address == null)
                {
                    return BadRequest();
                }

                address.AddressId = id;

                unitOfWork.AddressRepository.Update(address);
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SourceItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Address address = unitOfWork.AddressRepository
                    .SingleOrDefault(c => c.AddressId == id);

                if (address == null)
                {
                    return BadRequest();
                }

                unitOfWork.AddressRepository.Remove(address);

                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
