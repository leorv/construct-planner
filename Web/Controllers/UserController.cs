using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post(){
            try {
                return Ok();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UserController>/userVerify
        [HttpPost("UserVerify")]
        public ActionResult UserVerify([FromBody] User user)
        {
            try
            {
                if (user.Email == "leo@teste.com" && user.Password == "1234")
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest();
                }               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
