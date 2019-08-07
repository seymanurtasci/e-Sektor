using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace eSektör.Dal
{
    public class DalModule :NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<DbContext>().To<eSektorDbContext>();
        }
    }
}
