using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public interface ISymptomsDAO
    {

        public Task<List<Dictionary<string, string>>> getSymptoms();
    }
}
