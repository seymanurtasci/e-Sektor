using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektorEntities
{
    public class MemberSpeciality
    {
        public Guid MemberSpecialityId { get; set; }
        public Guid MemberId { get; set; }
        public Guid SpecialityId { get; set; }
        public bool IsDeleted { get; set; }


        public virtual Speciality Speciality{ get; set; }
        public virtual Members Member { get; set; }
    }
}
