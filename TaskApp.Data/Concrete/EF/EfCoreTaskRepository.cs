using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Data.Abstract;
using TaskApp.Entity;

namespace TaskApp.Data.Concrete.EF
{
    public class EfCoreTaskRepository : EfCoreGenericRepository<TaskAppContext, Entity.Task>, ITaskRepository
    {
        public void AddDeletedBack(int id)
        {
            using (var context = new TaskAppContext())
            {
                context.Tasks.Find(id).IsDelete = false;
                context.SaveChanges();
            }
        }

        public List<Entity.Task> DeletedTaskList()
        {
            using (var context = new TaskAppContext())
            {
                return context.Tasks.Where(x => x.IsDelete == true).ToList();
            }
        }
        public List<Entity.Task> NotDeletedTaskList()
        {
            using (var context = new TaskAppContext())
            {
                return context.Tasks.Where(x => x.IsDelete == false).ToList();
            }
        }

        public void TaskDelete(Entity.Task task)
        {
            using (var context = new TaskAppContext())
            {
                var _task = task;
                _task.IsDelete = true;
                context.Tasks.Update(_task);
                context.SaveChanges();
            }
        }
    }
}
