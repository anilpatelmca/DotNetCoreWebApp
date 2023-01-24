using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.JobApplication
{
    public class JobClassDto
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
