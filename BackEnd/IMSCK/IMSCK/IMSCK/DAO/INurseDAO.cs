using IMSCK.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public interface INurseDao
    {

        public Task<List<Dictionary<string, string>>> getNurses(CoordinatesDto credentials);
    }
}
