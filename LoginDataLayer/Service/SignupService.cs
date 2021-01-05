using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.DataLayer.Interface;
using LoginDataLayer;

namespace Login.DataLayer.Service
{
    public class SignupService : ISignupService
    {
        private LoginSignupModel _dbset;

        public SignupService(LoginSignupModel datasetModel)
        {
            _dbset = datasetModel;
        }

        public bool InsertSignupInfo(SignUp signUp)
        {
            try
            {
                _dbset.SignUps.Add(signUp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCustomer(SignUp signUp)
        {
            try
            {
                _dbset.SignUps.AddOrUpdate(signUp);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}