using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.LoginDto
{
   public class loginDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modifydate { get; set; }



    }
}
