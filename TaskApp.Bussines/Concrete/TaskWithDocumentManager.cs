using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Bussines.Abstract;
using TaskApp.Data.Abstract;
using TaskApp.Entity;

namespace TaskApp.Bussines.Concrete
{
    public class TaskWithDocumentManager : ITaskWithDocumentService
    {
        private ITaskWithDocumentRepository _taskWithDocumentRepository;

        public TaskWithDocumentManager(ITaskWithDocumentRepository taskWithDocumentRepository)
        {
            _taskWithDocumentRepository = taskWithDocumentRepository;
        }

        public List<TaskWithDocument> All()
        {
            return _taskWithDocumentRepository.All();
        }

        public void Create(TaskWithDocument entity)
        {
            throw new NotImplementedException();
        }

        public List<TaskWithDocument> GetAll()
        {
            return _taskWithDocumentRepository.GetAll();
        }

        public TaskWithDocument GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TaskWithDocumentCreate(List<TaskWithDocument> taskWithDocuments)
        {
            _taskWithDocumentRepository.TaskWithDocumentCreate(taskWithDocuments);
        }

        public void Update(TaskWithDocument entity)
        {
            throw new NotImplementedException();
        }
    }
}
