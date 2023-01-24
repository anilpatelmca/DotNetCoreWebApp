using DataInfo.Entities;
using Dto.LoginDto;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService userservices;
        public LoginController(ILoginService _userservices)
        {
            userservices = _userservices;

        }

        [HttpGet]
        public IActionResult Index(int ? id = null)
        {
           loginDto model = new loginDto();
            if(id.HasValue)
            {
                Login login = userservices.GetUserById(id.Value);
                model.Id = login.Id;
                model.Username = login.Username;
                model.Password = login.Password;
             }

            return View(model);
         
        }

        [HttpPost]
        public IActionResult Index(loginDto model)
        {
            try
            {
                bool isExist = false;
                Login jobApplication = null;
                if (model.Id > 0)
                    jobApplication = userservices.GetUserById(model.Id);

                isExist = jobApplication != null ? true : false; // here we can use turnary Operator 
                jobApplication = isExist ? jobApplication : new Login();
                model.Id = jobApplication.Id;
                model.Username = jobApplication.Username;
                model.Password = jobApplication.Password;

                userservices.Save(jobApplication);
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
