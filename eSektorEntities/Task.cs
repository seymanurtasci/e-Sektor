using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektorEntities
{
    public class Task
    {
        public Task()
        {
            Offers = new HashSet<Offers>();
            Specialities = new HashSet<Speciality>();
        }

        public Guid TaskId { get; set; }
        public Guid MemberId { get; set; }
        public string Description { get; set; }
        public Guid? OfferId { get; set; }
        public DateTime StartDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public decimal? Score { get; set; }
        public Boolean IsDeleted { get; set; }
        public Guid? PaymentMethodId { get; set; }
        public string TaskTitle { get; set; }

        public virtual Members Member { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<Offers> Offers { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }

    }
}
