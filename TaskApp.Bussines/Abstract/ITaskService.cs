using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Entity;

namespace TaskApp.Bussines.Abstract
{
    public interface ITaskService : IRepositoryService<Entity.Task>
    {
        List<Entity.Task> DeletedTaskList();
        List<Entity.Task> NotDeletedTaskList();
        void AddDeletedBack(int id);
        void TaskDelete(Entity.Task task);
    }
}
