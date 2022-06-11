using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Bussines.Abstract;
using TaskApp.WebUI.Models;

namespace TaskApp.WebUI.Views.Home
{
    public class TaskController : Controller
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult Index()
        {
            return View(_taskService.GetAll());
        }
        public IActionResult AddTask()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTask(AddTaskModel model)
        {
            if (ModelState.IsValid)
            {
                Entity.Task task = new Entity.Task()
                {
                    TaskContent = model.TaskContent,
                    TaskStateOfUrgency = model.TaskStateOfUrgency,
                    TaskFinishDate = model.TaskFinishDate
                };
                _taskService.Create(task);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult TaskEdit(int id)
        {
            var task = _taskService.GetById(id);
            AddTaskModel model = new AddTaskModel()
            {
                TaskId = task.TaskId,
                TaskContent = task.TaskContent,
                TaskStateOfUrgency = task.TaskStateOfUrgency,
                TaskFinishDate = task.TaskFinishDate
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult TaskEdit(AddTaskModel task)
        {
            if (ModelState.IsValid)
            {
                Entity.Task model = new Entity.Task()
                {
                    TaskId = task.TaskId,
                    TaskContent = task.TaskContent,
                    TaskStateOfUrgency = task.TaskStateOfUrgency,
                    TaskFinishDate = task.TaskFinishDate,
                    IsDelete = task.IsDelete
                };
                _taskService.Update(model);
                return RedirectToAction("Index");
            }
            return View(task);
        }
        public IActionResult TaskDelete(int id)
        {
            _taskService.TaskDelete(_taskService.GetById(id));
            return RedirectToAction("Index");
        }
    }
}
