using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektör.Entites.Mappings
{
    public class AuthorizeMapping: EntityTypeConfiguration<Authorize>
    {
        public AuthorizeMapping()
        {
            ToTable("Authorize").HasKey(au => au.AuthorizeId);

            Property(au => au.Type).HasColumnType("varchar").HasMaxLength(30);


            HasMany(m => m.Members).WithRequired(a=>a.Authorize).HasForeignKey(m => m.AuthorizeId).WillCascadeOnDelete(false);
        }
    }
}
