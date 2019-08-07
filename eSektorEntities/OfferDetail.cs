using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType.Classes;

namespace eSektorEntities
{
    public class OfferDetail
    {
        public Guid OfferDetailId { get; set; }
        public Guid OffreId { get; set; }
        [DisplayName("Marka")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "{0} 2 ile 50 karakter arasında olmalıdır.")]
        public string Brand { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} 1 ile 50 karakter arasında olmalıdır.")]
        public string Model { get; set; }
        [DisplayName("Açıklama")]
        [StringLength(700, MinimumLength = 2, ErrorMessage = "{0} 2 ile 700 karakter arasında olmalıdır.")]
        public string Description { get; set; }
        [DisplayName("Birim")]
        [Required(ErrorMessage = "{0} seçili olmalıdır.")]
        [Range(1, 5, ErrorMessage = "{0} seçili olmalıdır.")]//todo: yeni enum eklenmesi ihtimali için int.Max olarak üst sınır güncellenebilir
        public UnitEnum UnitEnum { get; set; }
        [DisplayName("Miktar")]
        [Required(ErrorMessage = "{0} dolu olmalıdır.")]
        [Range(1, 1000, ErrorMessage = "{0} 1 ile 1000 arasında olmalıdır.")]
        //Negatif veya pozitif sayılardan tam veya "." ile yazılmış ondalıklı sayıları kabul eder.
        [RegularExpression(@"^[-+]?\d+(\.\d+)?$", ErrorMessage = "{0} geçerli bir sayı olmalıdır.")]
        public decimal QuantityUnit { get; set; }
        [DisplayName("Birim Fiyat")]
        [Required(ErrorMessage = "{0} dolu olmalıdır.")]
        [Range(0, 10000, ErrorMessage = "{0} 0 ile 10000 arasında olmalıdır.")]
        //Negatif veya pozitif sayılardan tam veya "." ile yazılmış ondalıklı sayıları kabul eder.
        [RegularExpression(@"^[-+]?\d+(\.\d+)?$", ErrorMessage = "{0} geçerli bir sayı olmalıdır.")]
        public decimal UnitPrice { get; set; }
        

        public virtual Offers Offer { get; set; }


    }
}
