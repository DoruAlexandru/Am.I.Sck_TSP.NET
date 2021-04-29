using IMSCK.Model;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public interface IRegisterDao
    {
        public Task<bool> addUser(RegisterDto credentials);

    }
}
