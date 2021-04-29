using IMSCK.DAO;
using IMSCK.Service;
using System.Collections.Generic;
using Xunit;

namespace ImsckUnitTests
{
    public class SymptomTests
    {

        [Fact]
        public async void GetAllSymptoms()
        {
            SymptomService symptomService = new SymptomService(new SymptomsDao());

            ServiceResponse<List<Dictionary<string, string>>> response = await symptomService.getSymptoms();

            bool expected = true;
            bool actual = false;

            if (response.Data.Count != 0)
            {
                actual = true;
            }

            Assert.Equal(expected, actual);
        }
    }
}
