using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                 return Ok();
            }

            //catch (DomainException e)
            //{
            //    return BadRequest(e.Message);
            //}

            catch (Exception)
            {
                return StatusCode(500, "Erro");
            }
        }
    }
}
