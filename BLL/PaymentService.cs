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

namespace BLL
{
    public class PaymentService : IPaymentService
    {
        IUnitOfWork _uow;
        public PaymentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ServiceResult<List<PaymentMethod>> GetPaymentMethods()
        {
            List<PaymentMethod> pm = _uow.GetRepository<PaymentMethod>().GetList();
           
            return new ServiceResult<List<PaymentMethod>>("Okuma Başarılı", ResultState.Success, pm);
        }
    }
}
