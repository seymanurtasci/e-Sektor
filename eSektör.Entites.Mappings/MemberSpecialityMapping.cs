using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektör.Entites.Mappings
{
    public class MemberSpecialityMapping : EntityTypeConfiguration<MemberSpeciality>
    {
        public MemberSpecialityMapping()
        {
            ToTable("MemberSpeciality").HasKey(m => m.MemberSpecialityId);

            Property(m => m.MemberSpecialityId).HasColumnOrder(0);

            HasRequired(m => m.Speciality).WithMany(s => s.MemberSpecialities).HasForeignKey(m => m.SpecialityId).WillCascadeOnDelete(false);
            HasRequired(m => m.Member).WithMany(s => s.MemberSpecialities).HasForeignKey(m => m.MemberId).WillCascadeOnDelete(false);

        }
    }
}
