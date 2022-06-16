using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Data.Abstract
{
    public interface ITaskRepository : IRepository<Entity.Task>
    {
        void TaskDelete(Entity.Task task);
        List<Entity.Task> DeletedTaskList();
        List<Entity.Task> NotDeletedTaskList();
        void AddDeletedBack(int id);
    }
}
