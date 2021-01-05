using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginDataLayer;

namespace Login.DataLayer.Interface
{
    public interface ISignupService
    {
        bool InsertSignupInfo(SignUp signUp);
        bool UpdateCustomer(SignUp signUp);
    }
}