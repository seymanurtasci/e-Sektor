using CommonType.Classes;
using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IOfferService
    {
        ServiceResult<List<Offers>> GetOffers(Guid id);
        ServiceResult<List<OfferDetail>> GetOfferDetail(Guid id);
        ServiceResult<Offers> GetOffer(Guid id);
        ServiceResult Add(Offers offer, List<OfferDetail> offerDetails, Guid id);
        //todo: Guid userId olarak güncellenecek
        ServiceResult<List<Offers>> GetOffersByUserId(Guid? userId);
    }
}
