using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSektorEntities;

namespace eSektör.Entites.Mappings
{
    public class PaymentMethodMapping : EntityTypeConfiguration<PaymentMethod>
    {
        public PaymentMethodMapping()
        {
            ToTable("PaymentMethod").HasKey(t => t.PaymentMethodId);

            Property(p => p.PaymentMethodId).HasColumnOrder(0);
            Property(p => p.Type).HasMaxLength(30).IsRequired().IsUnicode(false);

            HasMany(p => p.Tasks).WithOptional(t => t.PaymentMethod).HasForeignKey(t => t.PaymentMethodId).WillCascadeOnDelete(false);
        }
    }
}
