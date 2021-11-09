using Domain.Entities;
using Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork){
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UserController>/UserVerify
        [HttpPost("UserVerify")]
        public ActionResult UserVerify([FromBody] User user)
        {
            try
            {
                // var returnedUser = unitOfWork


                if (user.Email == "leo@teste.com" && user.Password == "1234")
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Usuário ou senha inválido.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
