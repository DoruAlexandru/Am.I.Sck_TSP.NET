using IMSCK.DAO;
using IMSCK.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMSCK.Service
{
    public class NurseService
    {

        private readonly INurseDao nurseDAO;

        public NurseService(INurseDao nurseDAO)
        {
            this.nurseDAO = nurseDAO;
        }

        public async Task<ServiceResponse<List<Dictionary<string, string>>>> getNurses(CoordinatesDto credentials)
        {
            List<Dictionary<string, string>> nurses = await nurseDAO.getNurses(credentials);
            ServiceResponse<List<Dictionary<string, string>>> response = new ServiceResponse<List<Dictionary<string, string>>>();
            if (nurses.Count != 0)
            {
                response.Data = nurses;
                response.Message = "Nurses retrieved succesfully!";
            }
            else
            {
                response.Message = "Error retrieving nurses!";
                response.Success = false;
            }

            return response;
        }

    }
}
