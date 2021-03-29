using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IMSCK.Models;
using IMSCK.Service;

namespace IMSCK.API
{
    public class LoginController : ApiController
    {
        private LoginService loginService;
        public LoginController()
        {
            loginService = new LoginService();
        }

        // GET: api/Login
        public string Get()
        {
            return "API does not exist";
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "API does not exist";
        }

        // POST: api/Login
        public Boolean Post(LoginDetails credentials)
        {
            return loginService.credentialsService(credentials);
        }

        // PUT: api/Login/5
        public string Put(int id, [FromBody]string value)
        {
            return "API does not exist";
        }

        // DELETE: api/Login/5
        public String Delete(int id)
        {
            return "API does not exist";
        }
    }
}
