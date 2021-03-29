using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IMSCK.Models;
using IMSCK.DAO;

namespace IMSCK.Service
{

    public class LoginService
    {
        private LoginChecker loginChecker;

        public LoginService()
        {
            loginChecker = new LoginChecker();
        }

        public Boolean credentialsService(LoginDetails credentials)
        {
            return loginChecker.checkCredentials(credentials);
        }
    }
}