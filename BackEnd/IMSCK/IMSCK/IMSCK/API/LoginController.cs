using IMSCK.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using IMSCK.Service;
using IMSCK.DAO;
using System.Collections.Generic;

namespace IMSCK.API
{
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private LoginService loginService;

        public LoginController()
        {
            loginService = new LoginService();
        }

        [Route("checkUser")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDTO credentials)
        {
            ServiceResponse<Dictionary<string, string>> check = await loginService.loginCheck(credentials);
            if (check.Data != null){
                return Ok(check);
            }
            return BadRequest("Account not found");

        }

    }
}
