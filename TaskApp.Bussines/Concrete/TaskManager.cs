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
    public class TaskManager : ITaskService
    {
        private ITaskRepository _taskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Create(Entity.Task entity)
        {
            _taskRepository.Create(entity);
        }

        public List<Entity.Task> DeletedTaskList()
        {
            return _taskRepository.DeletedTaskList();
        }
        public List<Entity.Task> NotDeletedTaskList()
        {
            return _taskRepository.NotDeletedTaskList();
        }
        public List<Entity.Task> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public Entity.Task GetById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public void TaskDelete(Entity.Task task)
        {
            _taskRepository.TaskDelete(task);
        }

        public void Update(Entity.Task entity)
        {
            _taskRepository.Update(entity);
        }

        public void AddDeletedBack(int id)
        {
            _taskRepository.AddDeletedBack(id);
        }
    }
}
