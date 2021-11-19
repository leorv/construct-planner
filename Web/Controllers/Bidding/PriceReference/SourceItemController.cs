using Domain.Entities.Bidding.PriceReference;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding.PriceReference
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceItemController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public SourceItemController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: api/<SourceItemController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(unitOfWork.SourceItemRepository.GetAll());
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
                return Ok(unitOfWork.SourceItemRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SourceItemController>
        [HttpPost]
        public IActionResult Post([FromBody] SourceItem sourceItem)
        {
            try
            {
                unitOfWork.SourceItemRepository.Add(sourceItem);
                unitOfWork.SaveChanges();
                return Created("api/[controller]", sourceItem); // 201
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 404
            }
        }

        // PUT api/<SourceItemController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] SourceItem sourceItem)
        {
            try
            {
                if (sourceItem == null)
                {
                    return BadRequest();
                }

                sourceItem.SourceItemId = id;

                unitOfWork.SourceItemRepository.Update(sourceItem);
                unitOfWork.SaveChanges();
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
                SourceItem sourceItem = unitOfWork.SourceItemRepository
                    .SingleOrDefault(c => c.SourceItemId == id);

                if (sourceItem == null)
                {
                    return BadRequest();
                }

                unitOfWork.SourceItemRepository.Remove(sourceItem);
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
