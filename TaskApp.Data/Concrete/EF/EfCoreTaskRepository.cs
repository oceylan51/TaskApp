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
        public void TaskDelete(Entity.Task task)
        {
            using (var context = new TaskAppContext())
            {
                task.IsDelete = true;
                context.Tasks.Update(task);
                context.SaveChanges();
            }
        }
    }
}
