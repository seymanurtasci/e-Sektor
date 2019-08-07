using CommonType.Classes;
using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUI.Models
{
    public class OfferOfferDetailVM
    {
        public Offers Offer { get; set; }
        public List<OfferDetail> OfferDetails { get; set; }
        //public decimal Fee { get; set; }
        //public string Detail { get; set; }

        //public string Brand { get; set; }
        //public string Model { get; set; }
        //public string Description { get; set; }
        //public UnitEnum UnitEnum { get; set; }
        //public decimal QuantityUnit { get; set; }
        //public decimal UnitPrice { get; set; }
    }
}