using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSektorEntities;

namespace eSektör.Entites.Mappings
{
    public class TaskMapping : EntityTypeConfiguration<eSektorEntities.Task>
    {
        public TaskMapping()
        {
            ToTable("Task").HasKey(t => t.TaskId);

            Property(t => t.TaskId).HasColumnOrder(1).HasColumnType("uniqueidentifier");
            Property(t => t.Description).HasMaxLength(500).IsRequired().IsUnicode(false);
            Property(t => t.TaskTitle).HasMaxLength(70).IsRequired().IsUnicode(false);


            HasOptional(t => t.PaymentMethod).WithMany(c => c.Tasks).HasForeignKey(t => t.PaymentMethodId).WillCascadeOnDelete(false);
            HasRequired(t => t.Member).WithMany(c => c.Tasks).HasForeignKey(t => t.MemberId).WillCascadeOnDelete(false);
            HasMany(k => k.Offers).WithRequired(t => t.Task).HasForeignKey(o => o.TaskId).WillCascadeOnDelete(false);
            HasMany(s =>s.Specialities ).WithMany(t => t.Tasks).Map(st =>
                                st.MapLeftKey("TaskId")
                                .MapRightKey("SpecialityId")
                                .ToTable("TaskSpeciality")
                                );

        }
    }
}
