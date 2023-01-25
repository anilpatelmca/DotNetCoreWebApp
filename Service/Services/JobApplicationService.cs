using Core;
using DataInfo.Entities;
using FB.Core;
using LinqKit;
using Service.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
   public class JobApplicationService : IJobApplicationService
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

       
        public void Delete(int id)
        {
            repojobapplication.Delete(id);
        }

        public KeyValuePair<int, List<JobApplication>> Getjobapplicationlist(DataTableServerSide searchModel)
        {
            var predicate = FB.Core.PredicateBuilder.True<JobApplication>();
            predicate = CustomPredicate.BuildPredicate<JobApplication>(searchModel, new Type[] { typeof(JobApplication) });

            int totalCount;
            int page = searchModel.start == 0 ? 1 : (Convert.ToInt32(Decimal.Floor(Convert.ToDecimal(searchModel.start) / searchModel.length)) + 1);

            var jobApplications = repojobapplication
            .Query()
            .Filter(predicate)
            .OrderBy(x => x.OrderByDescending(oo => oo.Id)) //for the sorting 
            //.CustomOrderBy(u => u.OrderBy(searchModel, new Type[] { typeof(JobApplication) }))
            .GetPage(page, searchModel.length, out totalCount).ToList(); // for the pagination

            KeyValuePair<int, List<JobApplication>> resultResponse = new KeyValuePair<int, List<JobApplication>>(totalCount, jobApplications);

            return resultResponse;
        }





    }
}
