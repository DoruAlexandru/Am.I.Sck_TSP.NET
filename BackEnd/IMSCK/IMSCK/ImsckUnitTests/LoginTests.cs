using IMSCK.DAO;
using IMSCK.Model;
using IMSCK.Service;
using System.Collections.Generic;
using Xunit;

namespace ImsckUnitTests
{
    public class LoginTests
    {

        [Fact]
        public async void LoginSuccess()
        {
            LoginService loginService = new LoginService(new LoginDao());
            LoginDto credentials = new();
            credentials.Username = "Tudor";
            credentials.Password = "pass";
            ServiceResponse<Dictionary<string, string>> check = await loginService.loginCheck(credentials);

            bool expected = true;
            bool actual = false;

            if (check.Data != null)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void LoginFail()
        {
            LoginService loginService = new LoginService(new LoginDao());
            LoginDto credentials = new();
            credentials.Username = "Tudor";
            credentials.Password = "wrongPass";
            ServiceResponse<Dictionary<string, string>> check = await loginService.loginCheck(credentials);

            bool expected = false;
            bool actual = false;

            if (check.Data != null)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }
    }
}
