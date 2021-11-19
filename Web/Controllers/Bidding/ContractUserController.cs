using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractUserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ContractUserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<ContractUserController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.ContractUserRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ContractUserController>/5
        [HttpGet("{userId, contractId}")]
        public IActionResult Get([FromBody] int userId, int contractId)
        {
            try
            {
                return Ok(unitOfWork.ContractUserRepository
                    .SingleOrDefault(ag => ag.UserId == userId && ag.ContractId == contractId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ContractUserController>
        [HttpPost]
        public IActionResult Post([FromBody] ContractUser contractUser)
        {
            try
            {
                unitOfWork.ContractUserRepository.Add(contractUser);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", contractUser); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<ContractUserController>/5
        [HttpPut]
        public IActionResult Put([FromBody] ContractUser contractUser)
        {
            try
            {
                if (contractUser == null)
                {
                    return BadRequest();
                }

                var baseContractUser = unitOfWork.ContractUserRepository
                    .SingleOrDefault(a => a.UserId == contractUser.UserId
                        && a.ContractId == contractUser.ContractId);
                if (baseContractUser == null)
                {
                    return BadRequest();
                }

                unitOfWork.ContractUserRepository.Update(contractUser);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AdditiveAgreementController>/5
        [HttpDelete]
        public IActionResult Delete(ContractUser contractUser)
        {
            try
            {
                if (contractUser == null)
                {
                    return BadRequest();
                }

                var baseContractUser = unitOfWork.ContractUserRepository
                    .SingleOrDefault(a => a.UserId == contractUser.UserId
                        && a.ContractId == contractUser.ContractId);
                if (baseContractUser == null)
                {
                    return BadRequest();
                }

                unitOfWork.ContractUserRepository.Remove(contractUser);
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
