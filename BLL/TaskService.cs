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
using BLL;

namespace BLL
{
    public class TaskService : ITaskService
    {
        IUnitOfWork _uow;
        public TaskService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ServiceResult Add(eSektorEntities.Task task)
        {
            task.TaskId = Guid.NewGuid();
            _uow.GetRepository<eSektorEntities.Task>().Add(task);
            int ess = _uow.Save();
            if(ess > 0)
            {
                return new ServiceResult("Kayıt Başarılı", ResultState.Success);
            }
            return new ServiceResult("Bir Hata Nedeni İle Kayıt Gerçekleştirilemedi", ResultState.Error);
        }

        public ServiceResult<eSektorEntities.Task> Get()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<List<eSektorEntities.Task>> GetMembersTasks()
        {
            //var password = Request.Cookies["password"];
            string password = "1234";
            var sorgu = (from m in _uow.GetRepository<Members>().GetQuery(m => m.Password == password) select m.MemberId);
            Guid memberId = (Guid)sorgu.First();
            List<eSektorEntities.Task> membersTask = _uow.GetRepository<eSektorEntities.Task>().GetList(t=>t.MemberId==memberId);

            return new ServiceResult<List<eSektorEntities.Task>>("Okuma Başarılı", ResultState.Success,membersTask);

        }

        public ServiceResult<eSektorEntities.Task> TaskDetails(Guid id)
        {
            var task = _uow.GetRepository<eSektorEntities.Task>().Get(t => t.TaskId == id);

            return new ServiceResult<eSektorEntities.Task>("Okuma Başarılı", ResultState.Success, task);
        }

        public ServiceResult<List<eSektorEntities.Task>> GetTasks()
        { 
            List<eSektorEntities.Task> tasks = _uow.GetRepository<eSektorEntities.Task>().GetList();

            return new ServiceResult<List<eSektorEntities.Task>>("Okuma Başarılı", ResultState.Success,tasks);

           
        }

        public ServiceResult<IQueryable<ICollection<eSektorEntities.Task>>> GetTasksId(Guid id)
        {
            var query = (from t in _uow.GetRepository<Speciality>().GetQuery(t => t.SpecialityId == id) select t.Tasks);

            IQueryable<ICollection<eSektorEntities.Task>> tasks = query;

            return new ServiceResult<IQueryable<ICollection<eSektorEntities.Task>>>("Okuma Başarılı", ResultState.Success, tasks);
        }
    }
}
