using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Data.Abstract;
using TaskApp.Entity;

namespace TaskApp.Data.Concrete.EF
{
    public class EfCoreTaskAssignmentRepository : EfCoreGenericRepository<TaskAppContext, TaskAssignment>, ITaskAssignmentRepository
    {
        public List<TaskAssignment> GetAllTaskAssignment()
        {
            using (var context = new TaskAppContext())
            {
                return context.TaskAssignments.Include(x => x.Task).ToList();
            }
        }

        public List<TaskAssignment> GetByNotFinishedTaskAssignment()
        {
            using (var context = new TaskAppContext())
            {
                return context.TaskAssignments.Where(x => x.IsDelete == false).ToList();
            }
        }

        public List<TaskAssignment> GetByUserId(string id)
        {
            using (var context = new TaskAppContext())
            {
                return context.TaskAssignments.Include(x => x.Task).Where(x => x.UserId == id).ToList();
            }
        }
    }
}
