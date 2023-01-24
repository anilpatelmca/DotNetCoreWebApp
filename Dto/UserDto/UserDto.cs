using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.UserDto
{
   public  class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime ModifyBy { get; set; }
    }
}
