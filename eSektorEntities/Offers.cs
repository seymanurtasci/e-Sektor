using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektorEntities
{
    public class Offers
    {
        public Offers()
        {
            OfferDetails = new HashSet<OfferDetail>();
        }
        public Guid OfferId { get; set; }
        public Guid TaskId { get; set; }
        [DisplayName("Ücret")]
        [Required(ErrorMessage = "{0} dolu olmalıdır.")]
        [Range(0, 100000, ErrorMessage = "{0} 0 ile 100000 arasında olmalıdır.")]
        //Negatif veya pozitif sayılardan tam veya "." ile yazılmış ondalıklı sayıları kabul eder.
        [RegularExpression(@"^[-+]?\d+(\.\d+)?$", ErrorMessage = "{0} geçerli bir sayı olmalıdır.")]
        public decimal Fee { get; set; }
        public Guid MemberId { get; set; }
        [DisplayName("Detaylar")]
        //[Required(ErrorMessage = "{0} dolu olmalıdır.")]//db update istiyor
        //[RegularExpression(@"^\w{2,500}$", ErrorMessage = "{0} 2 ile 500 karakter arasında olmalıdır.")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "{0} 2 ile 500 karakter arasında olmalıdır.")]
        public string Detail { get; set; }
        [DisplayName("İptal Nedeni")]
        //[RegularExpression(@"^?\w{2,500}$", ErrorMessage = "{0} 2 ile 500 karakter arasında olmalıdır.")]        
        [StringLength(500, MinimumLength = 2, ErrorMessage = "{0} 2 ile 500 karakter arasında olmalıdır.")]
        public string CancellationReason { get; set; }
        [DisplayName("İptal Durumu")]
        public bool IsCancelled { get; set; }


        public virtual Members Member { get; set; }
        public virtual Task Task { get; set; }
        public virtual ICollection<OfferDetail> OfferDetails { get; set; }

    }
}
