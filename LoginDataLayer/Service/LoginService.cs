using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.DataLayer.Interface;
using LoginDataLayer;

namespace Login.DataLayer.Service
{
    public class LoginService : ILoginService
    {
        private LoginSignupModel _dbModel;

        public LoginService(LoginSignupModel datasetmodel)
        {
            _dbModel = datasetmodel;
        }
        public LoginDataLayer.Login GetLoginInfoByUserName(string userName)
        {
            return _dbModel.Logins.Find(userName);
        }
    }
}