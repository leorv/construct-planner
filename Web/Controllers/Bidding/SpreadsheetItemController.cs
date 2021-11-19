using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpreadsheetItemController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public SpreadsheetItemController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<SpreadsheetItemController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.SpreadsheetItemRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SpreadsheetItemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.SpreadsheetItemRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SpreadsheetItemController>
        [HttpPost]
        public IActionResult Post([FromBody] SpreadsheetItem spreadsheetItem)
        {
            try
            {
                unitOfWork.SpreadsheetItemRepository.Add(spreadsheetItem);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", spreadsheetItem); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<SpreadsheetController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] SpreadsheetItem spreadsheetItem)
        {
            try
            {
                if (spreadsheetItem == null)
                {
                    return BadRequest();
                }

                spreadsheetItem.SpreadsheetItemId = id;

                unitOfWork.SpreadsheetItemRepository.Update(spreadsheetItem);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SpreadsheetItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                SpreadsheetItem spreadsheetItem = unitOfWork.SpreadsheetItemRepository
                    .SingleOrDefault(c => c.SpreadsheetItemId == id);

                if (spreadsheetItem == null)
                {
                    return BadRequest();
                }

                unitOfWork.SpreadsheetItemRepository.Remove(spreadsheetItem);
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
