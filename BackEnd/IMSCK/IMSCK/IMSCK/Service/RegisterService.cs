using IMSCK.DAO;
using IMSCK.Model;
using System.Threading.Tasks;

namespace IMSCK.Service
{
    public class RegisterService
    {

        private readonly IRegisterDao registerDAO;

        public RegisterService(IRegisterDao registerDAO)
        {
            this.registerDAO = registerDAO;
        }

        public async Task<ServiceResponse<string>> addUser(RegisterDto credentials)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            if (credentials.Password.Equals(credentials.RePassword) && await registerDAO.addUser(credentials))
            {   
                
                response.Data = "Account created!";
                return response;
                
            }
            return response;
        }

    }
}
