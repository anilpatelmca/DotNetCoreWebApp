
using DataInfo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ILoginService : IDisposable
    {
        public Login GetUserById(int id);
        public void Save(Login login, bool isNew = true);
        public void Delete(int id);
    }
}
