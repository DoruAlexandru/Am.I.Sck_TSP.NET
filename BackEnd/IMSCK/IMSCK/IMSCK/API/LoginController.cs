using IMSCK.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using IMSCK.Service;
using IMSCK.DAO;
using System.Collections.Generic;
using IMSCK.Auth;

namespace IMSCK.API
{
    [Route("login/")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly LoginService loginService;

        public LoginController()
        {
            loginService = new LoginService(new LoginDao());

        }

        [Route("checkUser")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDto credentials)
        {
            ServiceResponse<Dictionary<string, string>> check = await loginService.loginCheck(credentials);
            if (check.Data != null){
                return Ok(check);
            }
            return BadRequest("Account not found");

        }

    }
}
