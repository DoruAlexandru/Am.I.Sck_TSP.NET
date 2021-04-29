using IMSCK.DAO;
using IMSCK.Model;
using IMSCK.Service;
using System;
using Xunit;

namespace ImsckUnitTests
{
    public class RegisterTests
    {

        [Fact]
        public async void RegisterSuccess()
        {
            RegisterService registerService = new RegisterService(new RegisterDao());
            RegisterDto credentials = new();

            string shortGuid = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            credentials.Username = $"User{shortGuid}";
            credentials.Password = "pass";
            credentials.RePassword = "pass";
            
            ServiceResponse<string> check = await registerService.addUser(credentials);

            bool expected = true;
            bool actual = false;

            if (check.Data != null)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void RegisterUserAlreadyExists()
        {
            RegisterService registerService = new RegisterService(new RegisterDao());
            RegisterDto credentials = new();
            credentials.Username = "Tudor";
            credentials.Password = "pass";
            credentials.RePassword = "pass";
            ServiceResponse<string> check = await registerService.addUser(credentials);

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
