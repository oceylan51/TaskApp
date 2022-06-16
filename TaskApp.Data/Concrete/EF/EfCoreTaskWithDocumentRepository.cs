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
    public class EfCoreTaskWithDocumentRepository : EfCoreGenericRepository<TaskAppContext, TaskWithDocument>, ITaskWithDocumentRepository
    {
        public List<TaskWithDocument> All()
        {
            using (var context = new TaskAppContext())
            {
                return context.TaskWithDocuments.Include(x => x.Document).ToList();
            }
        }

        public void TaskWithDocumentCreate(List<TaskWithDocument> taskWithDocuments)
        {
            using (var context = new TaskAppContext())
            {
                context.TaskWithDocuments.AddRange(taskWithDocuments);
                context.SaveChanges();
            }
        }
    }
}
