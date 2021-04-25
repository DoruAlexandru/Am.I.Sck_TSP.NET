using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace IMSCK.Model
{
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
