using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractAgreementController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ContractAgreementController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        // GET: api/<ContractAgreementController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.ContractAgreementRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ContractAgreementController>/5
        [HttpGet("{userId, contractId}")]
        public IActionResult Get([FromBody] int userId, int contractId)
        {
            try
            {
                return Ok(unitOfWork.ContractAgreementRepository
                    .SingleOrDefault(ag => ag.ContractId == contractId && ag.UserId == userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ContractAgreementController>
        [HttpPost]
        public IActionResult Post([FromBody] ContractAgreement contractAgreement)
        {
            try
            {
                unitOfWork.ContractAgreementRepository.Add(contractAgreement);
                return Created("api/[controller]", contractAgreement); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<ContractAgreementController>/5
        [HttpPut]
        public IActionResult Put([FromBody] ContractAgreement contractAgreement)
        {
            try
            {
                if (contractAgreement == null)
                {
                    return BadRequest();
                }

                var baseContractAgreement = unitOfWork.ContractAgreementRepository
                    .SingleOrDefault(a => a.ContractId == contractAgreement.ContractId
                        && a.UserId == contractAgreement.UserId);

                if (baseContractAgreement == null)
                {
                    return BadRequest();
                }

                unitOfWork.ContractAgreementRepository.Update(contractAgreement);
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ContractAgreementController>/5
        [HttpDelete]
        public IActionResult Delete(ContractAgreement contractAgreement)
        {
            try
            {
                if (contractAgreement == null)
                {
                    return BadRequest();
                }

                var baseContractAgreement = unitOfWork.ContractAgreementRepository
                    .SingleOrDefault(a => a.ContractId == contractAgreement.ContractId
                        && a.UserId == contractAgreement.UserId);
                if (baseContractAgreement == null)
                {
                    return BadRequest();
                }

                unitOfWork.ContractAgreementRepository.Remove(contractAgreement);

                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
