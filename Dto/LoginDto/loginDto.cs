using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Dto.LoginDto
{
   public class loginDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
       
        public DateTime Created { get; set; }
        public DateTime Modifydate { get; set; }



    }
}
