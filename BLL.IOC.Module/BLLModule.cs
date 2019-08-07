using BLL.Abstract;
using Core.DataAccess;
using Core.DataAccess.SqlServer.EntityFramework;
using eSektör.Dal;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IOC.Module
{
    public class BLLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<ITaskService>().To<TaskService>();
            Bind<IMemberService>().To<MemberService>();
            Bind<IOfferService>().To<OfferService>();
            Bind<ISpecialtyService>().To<SpecialtyService>();
            Bind<IPaymentService>().To<PaymentService>();

            List<INinjectModule> modules = new List<INinjectModule>();

            modules.Add(new DalModule());
            Kernel.Load(modules);
        }
    }
}
