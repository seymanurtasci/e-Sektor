using CommonType.Classes;
using eSektorEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ITaskService
    {
        ServiceResult<List<eSektorEntities.Task>> GetTasks();
        ServiceResult<IQueryable<ICollection<eSektorEntities.Task>>> GetTasksId(Guid id);
        ServiceResult<eSektorEntities.Task> Get();
        ServiceResult Add(eSektorEntities.Task task);
        ServiceResult<List<eSektorEntities.Task>> GetMembersTasks();
        ServiceResult<eSektorEntities.Task> TaskDetails(Guid id);

    }
}
