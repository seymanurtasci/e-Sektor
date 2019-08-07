using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektorEntities
{
    public class Members
    {
        public Members()
        {
            Tasks = new HashSet<Task>();
            Offers = new HashSet<Offers>();
            MemberSpecialities = new HashSet<MemberSpeciality>();
        }
        
        public Guid MemberId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal? AverageScore { get; set; }
        public Boolean IsDeleted { get; set; }
        public string TaxNo { get; set; }
        public Guid? AuthorizeId { get; set; }

        public virtual ICollection<Offers> Offers { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<MemberSpeciality> MemberSpecialities { get; set; }       
        public virtual Authorize Authorize { get; set; }
        
        

    }
}
