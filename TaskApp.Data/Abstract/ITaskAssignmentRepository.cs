using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Entity;

namespace TaskApp.Data.Abstract
{
    public interface ITaskAssignmentRepository : IRepository<TaskAssignment>
    {
        List<TaskAssignment> GetByNotFinishedTaskAssignment();
        List<TaskAssignment> GetByUserId(string id);
        List<TaskAssignment> GetAllTaskAssignment();
    }
}
