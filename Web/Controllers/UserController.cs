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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(unitOfWork.UserRepository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
                // var returnedUser = unitOfWork.UserRepository.Get(user.UserId);
                var returnedUser = unitOfWork.UserRepository.SingleOrDefault(u => u.Email == user.Email);

                if ( returnedUser == null ){
                    return BadRequest("Usuário não encontrado. Verifique as informações.");                    
                }
                if ( user.Email == returnedUser.Email && user.Password == returnedUser.Password ){
                    return Ok(returnedUser);
                }
                return BadRequest("Usuário ou senha inválido.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
