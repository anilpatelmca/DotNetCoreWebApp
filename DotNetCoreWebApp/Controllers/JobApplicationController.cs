using DataInfo.Entities;
using Dto.JobApplication;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Register;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly IJobApplicationService jobApplicationService;

        public JobApplicationController(IJobApplicationService _jobApplicationService)
        {
            this.jobApplicationService = _jobApplicationService;

        }

        [HttpGet]
        public IActionResult Index(int? id = null)
        {
            JobClassDto model = new JobClassDto();
            if (id.HasValue)
            {
                JobApplication jobApplication = jobApplicationService.GetJobApplicationById(id.Value);
                model.Id = jobApplication.Id;
                model.Title = jobApplication.Title;
                model.JobCode = jobApplication.JobCode;
                model.MinimumQualification = jobApplication.MinimumQualification;
                model.SortDescription = jobApplication.SortDescription;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(JobClassDto model)
        {
            try
            {
                bool isExist = false;
                JobApplication jobApplication = null;
                if (model.Id > 0)
                    jobApplication = jobApplicationService.GetJobApplicationById(model.Id);

                isExist = jobApplication != null ? true : false; // here we can use turnary Operator 
                jobApplication = isExist ? jobApplication : new JobApplication();

                jobApplication.Title = model.Title;
                jobApplication.CreatedBy = isExist ? jobApplication.CreatedBy : DateTime.Now;
                jobApplication.ModifyDate = DateTime.Now;
                jobApplication.CreatedBy = DateTime.Now;
                jobApplication.SortDescription = model.SortDescription;
                jobApplication.LastDate = model.LastDate;
                jobApplication.JobCode = model.JobCode;
                jobApplication.MinimumQualification = model.MinimumQualification;
                jobApplicationService.Save(jobApplication);
                Json(jobApplication);
                return RedirectToAction("Index", "JobApplication");

            }
            catch (Exception Ex)
            {
              Json(Ex.Message, false);
                return View(model);

            }
        }

        

    }
}