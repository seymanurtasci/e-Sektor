using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektorEntities
{
    public class Speciality
    {
        public Speciality()
        {
            Specialities = new HashSet<Speciality>();
            MemberSpecialities = new HashSet<MemberSpeciality>();
            Tasks = new HashSet<Task>();
        }

        public Guid SpecialityId { get; set; }
        public string Name { get; set; }
        public Guid? UpperSpeciality { get; set; }
        public Boolean IsDeleted { get; set; }

        public virtual Speciality BaseSpeciality { get; set; }
        public virtual ICollection<Speciality> Specialities { get; set; }
        public virtual ICollection<MemberSpeciality> MemberSpecialities { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
