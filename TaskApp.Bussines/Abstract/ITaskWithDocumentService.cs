using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Entity;

namespace TaskApp.Bussines.Abstract
{
    public interface ITaskWithDocumentService : IRepositoryService<TaskWithDocument>
    {
        void TaskWithDocumentCreate(List<TaskWithDocument> taskWithDocuments);
        List<TaskWithDocument> All();
    }
}
