using IMSCK.Model;
using System.Threading.Tasks;

namespace IMSCK.DAO
{
    public interface ILoginDao
    {
        public Task<bool> loginCheck(LoginDto credentials);

    }
}
