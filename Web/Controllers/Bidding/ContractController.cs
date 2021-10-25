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

        // GET: api/<ContractController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.ContractRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ContractController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.ContractRepository.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ContractController>
        [HttpPost]
        public IActionResult Post([FromBody] Contract contract)
        {
            try
            {
                unitOfWork.ContractRepository.AddAsync(contract);
                return Created("api/[controller]", contract);
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

                // ========================================================
                // Esta validação é um quebra galho. Extremamente vulnerável.
                // Posteriormente, criar um método para validar toda alteração
                // que é feita nas entidades. Isto é, se o usuário que está
                // fazendo as alterações tem a permissão pra isso.
                // ========================================================
                long _auxId = unitOfWork.ContractRepository
                    .SingleOrDefault(c => c.UserId == contract.UserId).UserId;
                if (!(contract.UserId == _auxId))
                {
                    return BadRequest($"O usuário não possui permissão para realizar alterações.");
                }
                // ========================================================

                unitOfWork.ContractRepository.Update(contract);
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

                return NoContent(); // 204
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
