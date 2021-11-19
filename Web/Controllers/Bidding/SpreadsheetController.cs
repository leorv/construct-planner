using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpreadsheetController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public SpreadsheetController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<SpreadsheetController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.SpreadsheetRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SpreadsheetController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.SpreadsheetRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SpreadsheetController>
        [HttpPost]
        public IActionResult Post([FromBody] Spreadsheet spreadsheet)
        {
            try
            {
                unitOfWork.SpreadsheetRepository.Add(spreadsheet);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", spreadsheet); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<SpreadsheetController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Spreadsheet spreadsheet)
        {
            try
            {
                if (spreadsheet == null)
                {
                    return BadRequest();
                }

                spreadsheet.SpreadsheetId = id;

                unitOfWork.SpreadsheetRepository.Update(spreadsheet);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SpreadsheetController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Spreadsheet spreadsheet = unitOfWork.SpreadsheetRepository
                    .SingleOrDefault(c => c.SpreadsheetId == id);

                if (spreadsheet == null)
                {
                    return BadRequest();
                }

                unitOfWork.SpreadsheetRepository.Remove(spreadsheet);
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
