using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUI.Models
{
    public class TaskSpecialityVM
    {
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }  
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public Guid PaymentMethodId { get; set; }


        public Guid SpecialityId { get; set; }

    }
}