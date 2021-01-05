using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginDataLayer;

namespace Login.DataLayer.UnitOfWork
{
    public class Repository : IDisposable
    {
        private LoginSignupModel Dataset = new LoginSignupModel();

        private GenericRepository<LoginDataLayer.Login> _loginRepository;

        public GenericRepository<LoginDataLayer.Login> LoginRepository
        {
            get
            {
                if (_loginRepository == null)
                {
                    _loginRepository = new GenericRepository<LoginDataLayer.Login>(Dataset);
                }

                return _loginRepository;
            }
        }

        private GenericRepository<SignUp> _signupRepository;

        public GenericRepository<SignUp> SignupRepository
        {
            get
            {
                if (_signupRepository == null)
                {
                    _signupRepository = new GenericRepository<SignUp>(Dataset);
                }

                return _signupRepository;
            }

            set
            {
                _signupRepository = value;
            }
        }

        public void Dispose()
        {
            Dataset?.Dispose();
        }

        public void Save()
        {
            Dataset.SaveChanges();
        }
    }
}