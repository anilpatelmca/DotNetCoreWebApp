using System;
using System.Collections.Generic;

#nullable disable

namespace DataInfo.Entities
{
    public partial class User
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
