using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditiveAgreementController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AdditiveAgreementController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<AdditiveAgreementController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.AdditiveAgreementRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AdditiveAgreementController>/5
        [HttpGet("{userId, additiveId}")]
        public IActionResult Get([FromBody] int userId,int additiveId)
        {
            try
            {
                return Ok(unitOfWork.AdditiveAgreementRepository
                    .SingleOrDefault(ag => ag.AdditiveId == additiveId && ag.UserId == userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AdditiveAgreementController>
        [HttpPost]
        public IActionResult Post([FromBody] AdditiveAgreement additiveAgreement)
        {
            try
            {
                unitOfWork.AdditiveAgreementRepository.Add(additiveAgreement);
                return Created("api/[controller]", additiveAgreement); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<AdditiveAgreementController>/5
        [HttpPut]
        public IActionResult Put([FromBody] AdditiveAgreement additiveAgreement)
        {
            try
            {
                if (additiveAgreement == null)
                {
                    return BadRequest();
                }

                var baseAdditiveAgreement = unitOfWork.AdditiveAgreementRepository
                    .SingleOrDefault(a => a.AdditiveId == additiveAgreement.AdditiveId
                        && a.UserId == additiveAgreement.UserId);
                if (baseAdditiveAgreement == null)
                {
                    return BadRequest();
                }

                unitOfWork.AdditiveAgreementRepository.Update(additiveAgreement);
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AdditiveAgreementController>/5
        [HttpDelete]
        public IActionResult Delete(AdditiveAgreement additiveAgreement)
        {
            try
            {
                if (additiveAgreement == null)
                {
                    return BadRequest();
                }

                var baseAdditiveAgreement = unitOfWork.AdditiveAgreementRepository
                    .SingleOrDefault(a => a.AdditiveId == additiveAgreement.AdditiveId 
                        && a.UserId == additiveAgreement.UserId);
                if (baseAdditiveAgreement == null)
                {
                    return BadRequest();
                }

                unitOfWork.AdditiveAgreementRepository.Remove(additiveAgreement);

                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
