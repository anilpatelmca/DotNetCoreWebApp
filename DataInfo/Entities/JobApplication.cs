using System;
using System.Collections.Generic;

#nullable disable

namespace DataInfo.Entities
{
    public partial class JobApplication
    {
        public int Id { get; set; }
        public int JobCode { get; set; }
        public string Title { get; set; }
        public string MinimumQualification { get; set; }
        public string SortDescription { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
