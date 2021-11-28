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
        // POST: api/<SpreadsheetController>/GetAll
        [HttpPost("GetAll")]
        public IActionResult GetAll([FromBody] int contractId)
        {
            try
            {
                return Ok(unitOfWork.SpreadsheetRepository.Find(s => s.ContractId == contractId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT Update api/<SpreadsheetController>/id
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Spreadsheet spreadsheet)
        {
            try
            {
                if (spreadsheet == null)
                {
                    Console.WriteLine("Erro: A planilha que foi enviada para atualização é nula.");
                    return BadRequest();
                }
                spreadsheet.SpreadsheetId = id;

                Console.WriteLine("Dentro da API");
                
                unitOfWork.SpreadsheetRepository.Update(spreadsheet);
                unitOfWork.SaveChanges();
                return NoContent(); // 204
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("A operação foi cancelado por um erro.");
                return BadRequest(ex.Message); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao tentar atualizar a planilha.");
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        public IActionResult Patch([FromRoute] int id, [FromBody] Spreadsheet spreadsheet)
        {
            try
            {
                if (spreadsheet == null)
                {
                    Console.WriteLine("Erro: A planilha que foi enviada para atualização é nula.");
                    return BadRequest();
                }

                spreadsheet.SpreadsheetId = id;

                unitOfWork.SpreadsheetRepository.Update(spreadsheet);
                unitOfWork.SaveChanges();
                return NoContent(); // 200
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao tentar atualizar a planilha.");
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
