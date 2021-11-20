using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        public ContractController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET api/<ContractController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.ContractRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ContractController>
        [HttpPost]
        public IActionResult Post([FromBody]
        // [Bind("Name, Object, Number, Year, Description, Date, Closed, ContractedUserId, UserId")]
        Contract contract)
        {
            try
            {
                unitOfWork.ContractRepository.Add(contract); 
                unitOfWork.SaveChanges();
                return Created("api/[controller]", contract); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // POST: api/<ContractController>/GetAll
        [HttpPost("GetAll")]
        public IActionResult GetAll([FromBody] Contract contract)
        {
            try
            {              
                return Ok(unitOfWork.ContractRepository.Find(c => c.UserId == contract.UserId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ContractController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Contract contract)
        {
            try
            {
                if (contract == null)
                {
                    return BadRequest();
                }

                contract.ContractId = id;

                unitOfWork.ContractRepository.Update(contract);
                unitOfWork.SaveChanges();

                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ContractController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Contract contract = unitOfWork.ContractRepository.SingleOrDefault(c => c.ContractId == id);

                if (contract == null)
                {
                    return BadRequest();
                }

                unitOfWork.ContractRepository.Remove(contract);
                unitOfWork.SaveChanges();
                Console.WriteLine("Contrato deletado.");

                return NoContent(); // 204
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
