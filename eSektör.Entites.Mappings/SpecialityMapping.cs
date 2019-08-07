using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektör.Entites.Mappings
{
    public class SpecialityMapping: EntityTypeConfiguration<Speciality>
    {
        public SpecialityMapping()
        {
            ToTable("Speciality").HasKey(sp => sp.SpecialityId);


            Property(sp => sp.SpecialityId).HasColumnOrder(1).HasColumnType("uniqueidentifier");
            Property(sp => sp.Name).HasColumnOrder(2).HasColumnType("varchar").HasMaxLength(40);
            Property(sp => sp.UpperSpeciality).HasColumnOrder(3).HasColumnType("uniqueidentifier").IsOptional();
            Property(sp => sp.IsDeleted).HasColumnOrder(4).HasColumnType("bit");

            HasMany(a => a.MemberSpecialities).WithRequired(s => s.Speciality).HasForeignKey(s => s.SpecialityId).WillCascadeOnDelete(false);

            HasMany(s => s.Specialities).WithRequired(s => s.BaseSpeciality).HasForeignKey(s => s.UpperSpeciality).WillCascadeOnDelete(false);
            HasMany(t => t.Tasks).WithMany(s => s.Specialities).Map(st =>
                                st.MapLeftKey("SpecialityId")
                                .MapRightKey("TaskId")
                                .ToTable("TaskSpeciality")
                                );

        }


    }
}
