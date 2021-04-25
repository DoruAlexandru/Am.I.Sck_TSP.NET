using IMSCK.Model;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    interface ILoginDAO
    {

        public Task<bool> loginCheck(LoginDTO credentials);

    }
}
