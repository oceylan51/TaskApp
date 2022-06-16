using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Entity;

namespace TaskApp.Data.Abstract
{
    public interface ITaskWithDocumentRepository : IRepository<TaskWithDocument>
    {
        void TaskWithDocumentCreate(List<TaskWithDocument> taskWithDocuments);
        List<TaskWithDocument> All();
    }
}
