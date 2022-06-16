using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApp.Bussines.Abstract;
using TaskApp.WebUI.Models;

namespace TaskApp.WebUI.Views.Home
{
    [Authorize]
    public class TaskController : Controller
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        //Silinmemiş Taskleri Listeler
        public IActionResult Index()
        {
            return View(_taskService.NotDeletedTaskList());
        }
        //Yeni Task Eklemek Oluşturduğumuz View a göndermek için kullandığımız method
        public IActionResult AddTask()
        {
            return View();
        }
        //Yeni Task ı Veri Tabanına Eklemek ve Tekrardan Index e Gönderdiğimiz Method
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
        //Düzenleyeceğimiz Task in Verilerini View a gönderdiğimiz Method
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
        //Viewdan güncel bilgileri aldığımız ve veri tabanına kayıt işlemini gerçekleştirdiğimiz method.
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
        public IActionResult DeletedTaskList()
        {
            return View(_taskService.DeletedTaskList());
        }
        public IActionResult AddDeletedBack(int id)
        {
            _taskService.AddDeletedBack(id);
            return RedirectToAction("Index");
        }
    }
}
