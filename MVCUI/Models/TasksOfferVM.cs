using CommonType.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUI.Models
{
    public class TasksOfferVM
    {
        public Guid OfferId { get; set; }
        public Guid TaskId { get; set; }
        public Guid MemberId { get; set; }
        public string CompanyName { get; set; }
        public decimal Fee { get; set; }
        public string Detail { get; set; }
        
    }
}