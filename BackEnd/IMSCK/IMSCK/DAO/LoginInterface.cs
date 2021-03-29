using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMSCK.Models;

namespace IMSCK.DAO
{
    interface LoginInterface
    {
        Boolean checkCredentials(LoginDetails credentials);
    }
}
