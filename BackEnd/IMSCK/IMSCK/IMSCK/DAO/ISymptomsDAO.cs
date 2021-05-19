using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public interface ISymptomsDao
    {

        public Task<List<Dictionary<string, string>>> getSymptoms();
    }
}
