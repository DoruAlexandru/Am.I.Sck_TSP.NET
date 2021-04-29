using IMSCK.DAO;
using IMSCK.Model;
using IMSCK.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IMSCK.API
{
    [Route("register/")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly RegisterService registerService;

        public RegisterController(RegisterService registerService)
        {
            this.registerService = registerService;

        }

        [Route("createAccount")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterDto credentials)
        {
            
            ServiceResponse<string> check = await registerService.addUser(credentials);
            if (check.Data != null)
            {
                return Ok(check);
            }
            
            return BadRequest("Account could not be created!");

        }
    }
}