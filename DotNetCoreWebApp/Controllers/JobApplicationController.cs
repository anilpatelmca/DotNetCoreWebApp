using Core;
using DataInfo.Entities;
using Dto.JobApplication;
using FB.Core;
using FB.Web;
using FB.Web.Controllers;
using Microsoft.AspNetCore.Http;
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
    public class JobApplicationController : BaseController
    {
        private readonly IJobApplicationService jobApplicationService;

        public JobApplicationController(IJobApplicationService _jobApplicationService)
        {
            this.jobApplicationService = _jobApplicationService;

        }

        [HttpGet]
        public IActionResult Index(int? id = null)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DataTableServerSide model)
        {

            KeyValuePair<int, List<JobApplication>> list = new KeyValuePair<int, List<JobApplication>>();
            list = jobApplicationService.Getjobapplicationlist(model);
            return Json(new
            {
                draw = model.draw,
                recordsTotal = list.Key,
                recordsFiltered = list.Key,
                data = list.Value.Select((c, index) => new List<object> {
                    c.Id,//0
                    model.start+index+1,//1
                    c.JobCode,
                    c.Title,//2
                    c.MinimumQualification,
                    c.SortDescription,

                     "<a data-toggle='modal' data-target='#modal-add-jobapplication'  href=" + Url.Action("AddEditJobApplication", "JobApplicationr", new { id = c.Id })
                      + " class='btn btn-primary grid-btn btn-sm'> Edit <i class='fa fa-edit'></i></a>&nbsp;" // for Edit button

                    + "<a data-toggle='modal' data-target='#modal-delete-jobapplication' href=" + Url.Action("Delete", "JobApplication", new { id = c.Id })
                    + " class='btn btn-danger grid-btn btn-sm ps3 delete-btn'> Delete <i class='fa fa-trash-o'></i></a>&nbsp;" // for Delete button


                })
            });
        }

        [HttpGet]
        public IActionResult AddEditJobApplication(int? id = null)
        {
            JobClassDto model = new JobClassDto();
            if(id.HasValue)
            {
                JobApplication jobApplication = jobApplicationService.GetJobApplicationById(id.Value);
                model.Id = jobApplication.Id;
                model.Title = jobApplication.Title;
                model.SortDescription = jobApplication.SortDescription;
                model.MinimumQualification = jobApplication.SortDescription;
                model.JobCode = jobApplication.JobCode;
            }
            return PartialView("_AddEditJobApplication",model);


        }

        
        [HttpPost]
        public IActionResult AddEditJobApplication(JobClassDto model)
        {
            try
            {
                bool isExist = false;
                var jobApplication = jobApplicationService.GetJobApplicationById(model.Id);

                isExist = jobApplication != null ? true : false;

                jobApplication = isExist ? jobApplication : new JobApplication();
                jobApplication.Title = model.Title;
                jobApplication.MinimumQualification = model.MinimumQualification;
                jobApplication.JobCode = model.JobCode;
                jobApplication.SortDescription = model.SortDescription;
                jobApplication.CreatedBy = isExist ? jobApplication.CreatedBy : DateTime.Now;
                jobApplication.ModifyDate = DateTime.Now;
                jobApplicationService.Save(jobApplication);
                ShowSuccessMessage("Success!", "Job Application saved successfully.", false);
                return RedirectToAction("Index", "JobApplication");

            }
            catch (Exception ex)
            {

                return RedirectToAction("Index", "JobApplication");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView("_ModalDelete", new Modal
            {

                Message = "Are you sure u want to delete this jobApplication?",
                Size = ModalSize.Small,
                Header = new ModalHeader { Heading = "Delete jobApplication" },
                Footer = new ModalFooter { SubmitButtonText = "Yes", CancelButtonText = "No" }


            });
        }

        /// <summary>
        /// To delete the membership type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="FC"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection FC)
        {
            string message;
            try
            {
                var jobApplication = jobApplicationService.GetJobApplicationById(id);
                if (jobApplication != null)
                {
                    jobApplicationService.Delete(id);
                }
                ShowSuccessMessage("Success!", "jobApplication Name has been deleted successfully.", false);
                return RedirectToAction("Index", "JobApplication");
            }
            catch (Exception ex)
            {
                message = ex.GetBaseException().Message;
                if (message.Contains("DELETE statement conflicted"))
                    message = "Error";

                ShowErrorMessage("Success!", message, false);
                return RedirectToAction("Index", "JobApplication");
            }
        }









    }
}