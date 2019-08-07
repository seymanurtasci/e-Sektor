using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektör.Entites.Mappings
{
    public class OffresMapping : EntityTypeConfiguration<Offers>
    {
        public OffresMapping()
        {
            ToTable("Offers").HasKey(o => o.OfferId);

            Property(o => o.OfferId).HasColumnOrder(1);
            Property(o => o.Detail).HasColumnType("varchar").HasMaxLength(500);
            Property(o => o.CancellationReason).HasColumnType("varchar").HasMaxLength(500);

            HasRequired(o => o.Member).WithMany(m => m.Offers).HasForeignKey(o => o.MemberId).WillCascadeOnDelete(false);

            HasRequired(o => o.Task).WithMany(t => t.Offers).HasForeignKey(o => o.TaskId).WillCascadeOnDelete(false);

            HasMany(o => o.OfferDetails).WithRequired(od => od.Offer).HasForeignKey(od => od.OffreId).WillCascadeOnDelete(false);
        }

    }
}
