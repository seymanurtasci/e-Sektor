using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSektör.Entites;
using System.Data.Entity.ModelConfiguration;
using eSektorEntities;

namespace eSektör.Entites.Mappings
{
    public class MemberMapping : EntityTypeConfiguration<Members>
    {
        public MemberMapping()
        {
            ToTable("Member").HasKey(t => t.MemberId);

            Property(m => m.MemberId).HasColumnOrder(1).HasColumnType("uniqueidentifier");
            Property(m => m.CompanyName).HasColumnType("varchar").HasMaxLength(30);
            Property(m => m.ContactName).HasColumnType("varchar").HasMaxLength(30);
            Property(m => m.Phone).HasColumnType("char").HasMaxLength(10);
            Property(m => m.Email).HasColumnType("varchar").HasMaxLength(50);
            Property(m => m.Password).HasColumnType("varchar").HasMaxLength(20);
            Property(m => m.TaxNo).HasColumnType("varchar").HasMaxLength(30);

            HasRequired(o => o.Authorize).WithMany(m => m.Members).HasForeignKey(m => m.AuthorizeId).WillCascadeOnDelete(false);

            HasMany(a =>a.Offers ).WithRequired(m => m.Member).HasForeignKey(p => p.MemberId).WillCascadeOnDelete(false);
            HasMany(a => a.Tasks).WithRequired(m => m.Member).HasForeignKey(p => p.MemberId).WillCascadeOnDelete(false);
            HasMany(a => a.MemberSpecialities).WithRequired(m => m.Member).HasForeignKey(p => p.MemberId).WillCascadeOnDelete(false);

        }
    }
}

