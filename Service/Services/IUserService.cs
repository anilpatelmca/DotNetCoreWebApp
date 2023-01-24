using DataInfo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
   public interface IUserService
   {
        public User GetuserById(int id);

        public void Save(User user, bool isNew = true);

        public void Delete(int id);


   }
}
