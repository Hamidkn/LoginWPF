using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.DataLayer.Interface
{
    public interface ILoginService
    {
        LoginDataLayer.Login GetLoginInfoByUserName(string userName);
    }
}
