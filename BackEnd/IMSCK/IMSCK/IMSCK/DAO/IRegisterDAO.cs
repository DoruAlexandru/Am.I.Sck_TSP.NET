using IMSCK.Model;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    interface IRegisterDAO
    {
        public Task<bool> addUser(RegisterDTO credentials);

    }
}
