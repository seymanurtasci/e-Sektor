using CommonType.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUI.Models
{
    public class OfferDetailVM
    {
        public Guid OfferDetailId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public UnitEnum UnitEnum { get; set; }
        public decimal QuantityUnit { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}