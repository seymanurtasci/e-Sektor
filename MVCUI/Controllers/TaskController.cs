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
    public class TaskController : Controller
    {

        ITaskService _ts;
        IMemberService _ms;
        ISpecialtyService _ss;
        IPaymentService _ps;
        public TaskController(ITaskService ts, IMemberService ms, ISpecialtyService ss,IPaymentService ps)
        {
            _ts = ts;
            _ms = ms;
            _ss = ss;
            _ps = ps;
        }
       
        public ActionResult GetTasks()
        {
            return View(_ts.GetTasks().Data);
        }

        public ActionResult GetTasksId(Guid id)
        {
            return View(_ts.GetTasksId(id).Data);
        }

        public ActionResult GetMembersTasks()
        {
            return View(_ts.GetMembersTasks().Data);
        }

        public ActionResult TaskDetails(Guid id)
        {
            var task = _ts.TaskDetails(id).Data;
            var member = _ms.GetMember(task.MemberId).Data;

            TaskMemberVM vm = new TaskMemberVM
            {
                TaskId = task.TaskId,
                MemberId = task.MemberId,
                Description = task.Description,
                StartDatetime = task.StartDatetime,
                EndDatetime = task.EndDatetime,
                TaskTitle = task.TaskTitle,
                CompanyName = member.CompanyName,
                ContactName = member.ContactName,
                Phone = member.Phone,
                Email = member.Email,
                AverageScore = member.AverageScore
            };

            return View(vm);
        }


        [HttpGet]
        public ActionResult PostTask()
        {
            var sp = _ss.GetSpecialties();
            var pm = _ps.GetPaymentMethods();
            ViewBag.List = sp.Data;
            ViewBag.PaymentMethods = pm.Data;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostTask(eSektorEntities.Task tsk)
        {
            var user = User.Identity.Name;
            var member = _ms.GetMemberByUsername(user);
            tsk.TaskId = Guid.NewGuid();
            tsk.MemberId = member.Data.MemberId;//olmzssa bu atamayı view de yap          
            var result = _ts.Add(tsk);
            ViewBag.Sonuc = result.Message;
            ViewBag.SonucDurumu = result.State;
            return View(tsk);
        }
    }
}