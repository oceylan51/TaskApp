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
    public class TaskAssignmentManager : ITaskAssignmentService
    {
        private ITaskAssignmentRepository _taskAssignmentRepository;

        public TaskAssignmentManager(ITaskAssignmentRepository taskAssignmentRepository)
        {
            _taskAssignmentRepository = taskAssignmentRepository;
        }

        public void Create(TaskAssignment entity)
        {
            _taskAssignmentRepository.Create(entity);
        }

        public List<TaskAssignment> GetAll()
        {
            return _taskAssignmentRepository.GetAll();
        }

        public List<TaskAssignment> GetAllTaskAssignment()
        {
            return _taskAssignmentRepository.GetAllTaskAssignment();
        }

        public TaskAssignment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskAssignment> GetByNotFinishedTaskAssignment()
        {
            return _taskAssignmentRepository.GetByNotFinishedTaskAssignment();
        }

        public List<TaskAssignment> GetByUserId(string id)
        {
            return _taskAssignmentRepository.GetByUserId(id);
        }

        public void Update(TaskAssignment entity)
        {
            throw new NotImplementedException();
        }
    }
}
