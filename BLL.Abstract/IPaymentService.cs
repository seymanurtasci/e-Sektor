using CommonType.Classes;
using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IPaymentService
    {
        ServiceResult<List<PaymentMethod>> GetPaymentMethods();
    }
}
