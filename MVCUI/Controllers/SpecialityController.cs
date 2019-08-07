using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Abstract;

namespace MVCUI.Controllers
{
    public class SpecialityController : Controller
    {
        ISpecialtyService _ss;
        public SpecialityController(ISpecialtyService ss)
        {
            _ss = ss;
        }

        [ChildActionOnly]
        public PartialViewResult GetSpeciality()
        {
            return PartialView("_PartialSpeciality",_ss.GetSpecialties().Data);
        }
    }
}