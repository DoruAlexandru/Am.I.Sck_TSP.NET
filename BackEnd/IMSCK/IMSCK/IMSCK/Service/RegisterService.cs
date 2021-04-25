using IMSCK.DAO;
using IMSCK.Model;
using System.Threading.Tasks;

namespace IMSCK.Service
{
    public class RegisterService
    {

        IRegisterDAO registerDAO;

        public RegisterService()
        {
            this.registerDAO = new RegisterDAO();
        }

        public async Task<ServiceResponse<string>> addUser(RegisterDTO credentials)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            if (credentials.Password.Equals(credentials.RePassword))
            {   
                if (await registerDAO.addUser(credentials))
                {
                    response.Data = "Account created!";
                    return response;
                }
            }
            return response;
        }

    }
}
