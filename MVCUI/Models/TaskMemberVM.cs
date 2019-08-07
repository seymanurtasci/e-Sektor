using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUI.Models
{
    public class TaskMemberVM
    {
        public Guid TaskId { get; set; }
        public Guid MemberId { get; set; }
        public string Description { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public string TaskTitle { get; set; }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? AverageScore { get; set; }
    }
}