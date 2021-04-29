using IMSCK.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.Service
{
    public class SymptomService
    {

        private readonly ISymptomsDao symptomsDAO;

        public SymptomService(ISymptomsDao symptomsDAO)
        {
            this.symptomsDAO = symptomsDAO;
        }

        public async Task<ServiceResponse<List<Dictionary<string, string>>>> getSymptoms()
        {
            List<Dictionary<string, string>> symptoms = await symptomsDAO.getSymptoms();
            ServiceResponse<List<Dictionary<string, string>>> response = new ServiceResponse<List<Dictionary<string, string>>>();
            if (symptoms.Count != 0)
            {
                response.Data = symptoms;
                response.Message = "Symptoms retrieved succesfully!";
            }
            else
            {
                response.Message = "Error retrieving symptoms!";
                response.Success = false;
            }
            
            return response;
        }

    }
}
