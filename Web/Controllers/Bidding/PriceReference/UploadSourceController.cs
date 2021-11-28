using Domain.Entities.Bidding.PriceReference;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers.Bidding.PriceReference
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadSourceController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public UploadSourceController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post([FromBody] SourceItem sourceItem)
        {
            try
            {
                unitOfWork.SourceItemRepository.Add(sourceItem);
                unitOfWork.SaveChanges();
                Console.WriteLine(sourceItem.ToString());
                Console.WriteLine("Item inserido com sucesso.");

                return Ok();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Erro com a leitura/escrita do arquivo. Erro: " + ex.ToString());
                return BadRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao inserir os dados da source."+ ex.Message);
                return BadRequest(ex);
            }
        }
    }
}

