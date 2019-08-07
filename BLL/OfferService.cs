using BLL.Abstract;
using CommonType.Classes;
using CommonType.Enums;
using Core.DataAccess;
using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = eSektorEntities.Task;

namespace BLL
{
    public class OfferService : IOfferService
    {
        IUnitOfWork _uow;
        public OfferService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ServiceResult<Offers> GetOffer(Guid id)//bakılacak
        {
             var Offer = _uow.GetRepository<Offers>().Get(o => o.OfferId == id);

            return new ServiceResult<Offers>("Okuma Başarılı", ResultState.Success, Offer);
        }

        public ServiceResult<List<OfferDetail>> GetOfferDetail(Guid id)//bakılacak
        {
            List<OfferDetail> offerDetails = _uow.GetRepository<OfferDetail>().GetList(od => od.OffreId == id);
            return new ServiceResult<List<OfferDetail>>("Okuma Başarılı", ResultState.Success, offerDetails);
        }

        public ServiceResult<List<Offers>> GetOffers(Guid id)
        {
            List<Offers> tasksOffer = _uow.GetRepository<Offers>().GetList(o => o.TaskId == id);

            return new ServiceResult<List<Offers>>("Okuma Başarılı", ResultState.Success, tasksOffer);
        }
        public ServiceResult Add(Offers offer, List<OfferDetail> offerDetails, Guid id)
        {
            //todo: login olana göre güncellenecek
            string password = "1234";
            var sorgu = (from m in _uow.GetRepository<Members>().GetQuery(m => m.Password == password) select m.MemberId);
            Guid memberId = (Guid)sorgu.First();

            offer.TaskId = id;
            offer.OfferId = Guid.NewGuid();
            offer.MemberId = memberId;
            offer.IsCancelled = false;

            _uow.GetRepository<Offers>().Add(offer);

            foreach (OfferDetail offerDetail in offerDetails)
            {
                offerDetail.OfferDetailId = Guid.NewGuid();
                offerDetail.OffreId = offer.OfferId;
                _uow.GetRepository<OfferDetail>().Add(offerDetail);
            }

            int ess = _uow.Save();

            if (ess > 0)
            {
                return new ServiceResult("Kayıt başarılıdır.", ResultState.Success);
            }
            return new ServiceResult("Bir hata nedeniyle kayıt gerçekleşmedi.", ResultState.Error);
        }
        public ServiceResult<List<Offers>> GetOffersByUserId(Guid? userId)
        {
            //todo: methodun Guid? userId parametresi Guid userId olarak güncellenecek
            //todo: login olana göre güncellenecek
            string password = "1234";
            var sorgu = (from m in _uow.GetRepository<Members>().GetQuery(m => m.Password == password) select m.MemberId);
            Guid memberId = (Guid)sorgu.First();

            var offers = _uow.GetRepository<Offers>().GetList(o => o.MemberId == memberId);
            return new ServiceResult<List<Offers>>("Okuma Başarılı", ResultState.Success, offers);
        }
    }
}
