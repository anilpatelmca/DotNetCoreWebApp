using DataInfo.Entities;
using Service.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
    class JobApplicationService : IJobApplicationService
    {
        private IRepository<JobApplication> repojobapplication;

        public JobApplicationService(IRepository<JobApplication> _repoAddress)
        {
            repojobapplication = _repoAddress;
        
        }

        public JobApplication GetJobApplicationById(int id)
        {
            return repojobapplication.FindById(id);
        }

        public void Save(JobApplication JobApplication, bool isNew = true)
        {
            if (isNew)
            {
                repojobapplication.Insert(JobApplication);
            }
            else
            {
                repojobapplication.Update(JobApplication);
            }
        }

        /// <summary>
        /// To delete address
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            repojobapplication.Delete(id);
        }

        //public KeyValuePair<int, List<JobApplication>> GetjobapplicationByid(DataTableServerSide searchModel)
        //{
        //    var predicate = PredicateBuilder.True<JobApplication>();
        //    predicate = CustomPredicate.BuildPredicate<JobApplication>(searchModel, new Type[] { typeof(JobApplication) });
        //    //predicate = predicate.And(m => m.FoodbankId == foodBankId);

        //    int totalCount;
        //    int page = searchModel.start == 0 ? 1 : (Convert.ToInt32(Decimal.Floor(Convert.ToDecimal(searchModel.start) / searchModel.length)) + 1);

        //    var ProfessionList = repojobapplication
        //    .Query()
        //    .Filter(predicate)
        //    .OrderBy(x => x.OrderByDescending(oo => oo.Id)) //for the sorting 
        //    .CustomOrderBy(u => u.OrderBy(searchModel, new Type[] { typeof(JobApplication) }))
        //    .GetPage(page, searchModel.length, out totalCount).ToList(); // for the pagination
        //    KeyValuePair<int, List<JobApplication>> resultResponse = new KeyValuePair<int, List<JobApplication>>(totalCount, ProfessionList);

        //    return resultResponse;

        //}



    }
}
