using DataInfo.Entities;
using Service.Register;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> repoUser;

        public UserService(IRepository<User> _repoUser)
        {
            repoUser = _repoUser;

        }

        public User GetuserById(int id)
        {
            return repoUser.FindById(id);
        }

        public void Save(User user, bool isNew = true)
        {
            if (isNew)
            {
                repoUser.Insert(user);
            }
            else
            {
                repoUser.Update(user);
            }
        }

        /// <summary>
        /// To delete address
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            repoUser.Delete(id);
        }


    }
}
