using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektör.Entites.Mappings
{
    public class OfferDetailMapping : EntityTypeConfiguration<OfferDetail>
    {
        public OfferDetailMapping()
        {
            ToTable("OfferDetail").HasKey(o => o.OfferDetailId);

            Property(o => o.Brand).HasMaxLength(50).IsUnicode(false);
            Property(o => o.Model).HasMaxLength(50).IsUnicode(false);
            Property(o => o.Description).HasMaxLength(700).IsUnicode(false);
           



            HasRequired(od => od.Offer).WithMany(o => o.OfferDetails).HasForeignKey(od => od.OffreId).WillCascadeOnDelete(false);


        }
    }
}
