using BLL.Abstract;
using eSektorEntities;
using MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI.Controllers
{
    public class OfferController : Controller
    {
        IOfferService _os;
        IMemberService _ms;
        public OfferController(IOfferService os, IMemberService ms)
        {
            _os = os;
            _ms = ms;
        }

        public ActionResult GetTasksOffers(Guid id)
        {
            List<TasksOfferVM> tasksOfferVMs = new List<TasksOfferVM>();
            
            foreach (var offer in _os.GetOffers(id).Data)
            {
                TasksOfferVM tasksOffer = new TasksOfferVM
                {
                    OfferId = offer.OfferId,
                    Detail = offer.Detail,
                    Fee = offer.Fee,
                    MemberId = offer.MemberId
                };
                var membersCompany = _ms.GetMember(tasksOffer.MemberId).Data;
                tasksOffer.CompanyName = membersCompany.CompanyName;

                tasksOfferVMs.Add(tasksOffer);
            }
            return View(tasksOfferVMs);
           
        }
        public ActionResult GetOfferDetails(Guid id)
        {
            var offersFee = _os.GetOffer(id).Data.Fee;
            ViewBag.fee = offersFee;
            var offerDetails = _os.GetOfferDetail(id).Data;

            return View(offerDetails);
        }

        public ActionResult Add(Guid id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(OfferOfferDetailVM offerOfferDetailVM, Guid id)
        {
            var result = _os.Add(offerOfferDetailVM.Offer, offerOfferDetailVM.OfferDetails, id);
            ViewBag.Sonuc = result.Message;
            ViewBag.SonucState = result.State;
            return View(offerOfferDetailVM);
        }
        //todo: methodun Guid? userId parametresi Guid userId olarak güncellenecek
        public ActionResult GetUserOffers(Guid? userId)
        {
            var result = _os.GetOffersByUserId(null).Data;
            return View(result);
        }
        public ActionResult Details(Guid id)
        {
            OfferOfferDetailVM offerOfferDetailVM = new OfferOfferDetailVM();
            offerOfferDetailVM.Offer = _os.GetOffer(id).Data;
            offerOfferDetailVM.OfferDetails = _os.GetOfferDetail(id).Data;
            return View(offerOfferDetailVM);
        }
    }
}