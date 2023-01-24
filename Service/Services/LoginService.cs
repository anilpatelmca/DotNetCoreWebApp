
using DataInfo.Entities;
using Service.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class LoginService : ILoginService
    {


        private IRepository<Login> repologin;

        public LoginService(IRepository<Login> _repologin)
        {
            repologin = _repologin;

        }

        public Login GetUserById(int id)
        {
            return repologin.FindById(id);
        }

        public void Save(Login login, bool isNew = true)
        {
            if (isNew)
            {
                repologin.Insert(login);
            }
            else
            {
                repologin.Update(login);
            }
        }

        /// <summary>
        /// To delete address
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            repologin.Delete(id);
        }





        public void Dispose()
        {
            if (repologin != null)
            {
                repologin.Dispose();
                repologin = null;
            }
        }
    }
}
