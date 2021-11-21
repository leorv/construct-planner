using Domain.Entities.Bidding;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditiveSpreadsheetItemController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public AdditiveSpreadsheetItemController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<AdditiveSpreadsheetItemController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.AdditiveSpreadsheetItemRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AdditiveSpreadsheetItemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.AdditiveSpreadsheetItemRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AdditiveSpreadsheetItemController>
        [HttpPost]
        public IActionResult Post([FromBody] AdditiveSpreadsheetItem AdditiveSpreadsheetItem)
        {
            try
            {
                Console.WriteLine("Enviando para a unity of work.");
                unitOfWork.AdditiveSpreadsheetItemRepository.Add(AdditiveSpreadsheetItem);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", AdditiveSpreadsheetItem); // 201
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
                return Ok(unitOfWork.AdditiveSpreadsheetItemRepository.Find(a => a.AdditiveLevelId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AdditiveSpreadsheetItemController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] AdditiveSpreadsheetItem AdditiveSpreadsheetItem)
        {
            try
            {
                if (AdditiveSpreadsheetItem == null)
                {
                    return BadRequest();
                }

                AdditiveSpreadsheetItem.AdditiveSpreadsheetItemId = id;

                unitOfWork.AdditiveSpreadsheetItemRepository.Update(AdditiveSpreadsheetItem);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AdditiveSpreadsheetItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                AdditiveSpreadsheetItem AdditiveSpreadsheetItem = unitOfWork.AdditiveSpreadsheetItemRepository.SingleOrDefault(c => c.AdditiveSpreadsheetItemId == id);

                if (AdditiveSpreadsheetItem == null)
                {
                    return BadRequest();
                }

                unitOfWork.AdditiveSpreadsheetItemRepository.Remove(AdditiveSpreadsheetItem);
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
