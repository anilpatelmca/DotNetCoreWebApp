using System;
using System.Collections.Generic;

#nullable disable

namespace DataInfo.Entities
{
    public partial class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modifydate { get; set; }
    }
}
