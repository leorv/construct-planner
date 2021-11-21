using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditiveSpreadsheetController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AdditiveSpreadsheetController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<AdditiveSpreadsheetController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.AdditiveSpreadsheetRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AdditiveSpreadsheetController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.AdditiveSpreadsheetRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AdditiveSpreadsheetController>
        [HttpPost]
        public IActionResult Post([FromBody] AdditiveSpreadsheet AdditiveSpreadsheet)
        {
            try
            {
                Console.WriteLine("Enviando para a unity of work.");
                unitOfWork.AdditiveSpreadsheetRepository.Add(AdditiveSpreadsheet);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", AdditiveSpreadsheet); // 201
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
                return Ok(unitOfWork.AdditiveSpreadsheetRepository.Find(a => a.AdditiveId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AdditiveSpreadsheetController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AdditiveSpreadsheet AdditiveSpreadsheet)
        {
            try
            {
                if (AdditiveSpreadsheet == null)
                {
                    return BadRequest();
                }

                AdditiveSpreadsheet.AdditiveSpreadsheetId = id;

                unitOfWork.AdditiveSpreadsheetRepository.Update(AdditiveSpreadsheet);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AdditiveSpreadsheetController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                AdditiveSpreadsheet AdditiveSpreadsheet = unitOfWork.AdditiveSpreadsheetRepository.SingleOrDefault(c => c.AdditiveSpreadsheetId == id);

                if (AdditiveSpreadsheet == null)
                {
                    return BadRequest();
                }

                unitOfWork.AdditiveSpreadsheetRepository.Remove(AdditiveSpreadsheet);
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
