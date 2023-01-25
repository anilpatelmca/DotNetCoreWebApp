using DataInfo.Entities;
using Dto.LoginDto;
using Dto.UserDto;
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
        private readonly ILoginService loginservices;
        private readonly IUserService userservices;
        public LoginController(ILoginService _loginservices, IUserService _userService)
        {
            loginservices = _loginservices;
            userservices = _userService;

        }

        [HttpGet]
        public IActionResult Index(int? id = null)
        {
            loginDto model = new loginDto();

            return View(model);

        }

        [HttpPost]
        public IActionResult Index(loginDto model)
        {

            try
            {
                bool isExist = false;
                Login jobApplication = null;
                if (ModelState.IsValid)
                {
                    bool check = userservices.CheckUserExist(model.Email, model.Password);
                    if (check)
                    {
                        return RedirectToAction("Index", "JobApplication");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User");
                        return View(model);
                    }
                }


                return View(model);



            }
            catch (Exception Ex)
            {

                return View(model);

            }





        }
        [HttpGet]
        public IActionResult Register(int? id = null)
        {
            UserDto model = new UserDto();
            if (id.HasValue)
            {
                User user = userservices.GetuserById(id.Value);
                model.UserId = user.UserId;
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Password = user.Password;
                model.Email = user.Email;

            }

            return View(model);

        }

        [HttpPost]
        public IActionResult Register(UserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            try
            {
                bool isExist = false;
                User jobApplication = null;
                if (model.UserId > 0)
                    jobApplication = userservices.GetuserById(model.UserId);

                isExist = jobApplication != null ? true : false; // here we can use turnary Operator 
                jobApplication = isExist ? jobApplication : new User();
                jobApplication.UserId = model.UserId;
                jobApplication.FirstName = model.FirstName;
                jobApplication.Email = model.Email;
                jobApplication.LastName = model.LastName;
                //model.ModifyBy = DateTime.Now;
                //model.CreatedBy = DateTime.Now;
                jobApplication.ModifyBy = DateTime.Now;
                jobApplication.CreatedBy = isExist ? jobApplication.CreatedBy : DateTime.Now;
                //model.CreatedBy = isExist ? jobApplication.CreatedBy : DateTime.Now;
                jobApplication.Password = model.Password;

                userservices.Save(jobApplication);
                return RedirectToAction("Index", "Login");


            }
            catch (Exception Ex)
            {

                return View(model);

            }





        }
    }
}
