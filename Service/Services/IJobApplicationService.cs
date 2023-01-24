using DataInfo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
   public  interface IJobApplicationService
    {
        public JobApplication GetJobApplicationById(int id);
        public void Save(JobApplication JobApplication, bool isNew = true);

        public void Delete(int id);
        //public KeyValuePair<int, List<JobApplication>> GetjobapplicationByid(DataTableServerSide searchModel);




    }
}
