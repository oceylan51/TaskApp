using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskApp.Bussines.Abstract;
using TaskApp.Entity;
using TaskApp.WebUI.Identity;
using TaskApp.WebUI.Models;

namespace TaskApp.WebUI.Controllers
{
    [Authorize]
    public class TaskAssignmentController : Controller
    {
        private ITaskAssignmentService _taskAssignmentService;
        private ITaskService _taskService;
        private UserManager<User> _userManager;
        private ITaskWithDocumentService _taskWithDocumentService;
        private IDocumentService _documentService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TaskAssignmentController(ITaskAssignmentService taskAssignmentService, ITaskService taskService, UserManager<User> userManager, ITaskWithDocumentService taskWithDocumentService, IDocumentService documentService, RoleManager<IdentityRole> roleManager)
        {
            _taskAssignmentService = taskAssignmentService;
            _taskService = taskService;
            _userManager = userManager;
            _taskWithDocumentService = taskWithDocumentService;
            _documentService = documentService;
            _roleManager = roleManager;
        }

        [Authorize]
        public IActionResult Index()
        {

            var taskAssignment = _taskAssignmentService.GetAllTaskAssignment();
            ViewBag.Documents = _taskWithDocumentService.All();
            ViewBag.UserId = _userManager.GetUserId(User);
            return View(taskAssignment);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTask()
        {
            ViewBag.Users = new SelectList(_userManager.Users, "Id", "FirstName");
            ViewBag.Tasks = new SelectList(_taskService.GetAll(), "TaskId", "TaskContent");
            ViewBag.Documents = _documentService.GetAll();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddTask(TaskAssignment task, int[] documentIds)
        {
            _taskAssignmentService.Create(task);
            List<TaskWithDocument> taskWithDocuments = new List<TaskWithDocument>();
            for (int i = 0; i < documentIds.Length; i++)
            {
                TaskWithDocument taskWithDocument = new TaskWithDocument();
                taskWithDocument.TaskId = task.TaskId;
                taskWithDocument.DocumentId = documentIds[i];
                taskWithDocuments.Add(taskWithDocument);
            }
            _taskWithDocumentService.TaskWithDocumentCreate(taskWithDocuments);
            return RedirectToAction("Index");
        }
        public IActionResult ImageShow(int id)
        {
            return View(_documentService.GetById(id));
        }
        public IActionResult TaskAssignmentDetails(int id)
        {
            ViewBag.Documents = _taskWithDocumentService.All();
            return View(_taskService.GetById(id));
        }
        public IActionResult TaskAssignmentFinish(int id)
        {
            ViewBag.AddedDocuments = _documentService.GetDocumentsAddedById(_userManager.GetUserId(User));
            ViewBag.Documents = _taskWithDocumentService.All();
            return View(_taskService.GetById(id));
        }
        [HttpPost]
        public IActionResult TaskAssignmentFinish(int taskId, DateTime finishingDate, string description, int[] documentIds)
        {
            List<TaskWithDocument> taskWithDocuments = new List<TaskWithDocument>();
            for (int i = 0; i < documentIds.Length; i++)
            {
                TaskWithDocument taskWithDocument = new TaskWithDocument();
                taskWithDocument.TaskId = taskId;
                taskWithDocument.DocumentId = documentIds[i];
                taskWithDocuments.Add(taskWithDocument);
            }
            _taskWithDocumentService.TaskWithDocumentCreate(taskWithDocuments);
            var inComingTask = _taskService.GetById(taskId);
            Entity.Task task = new Entity.Task()
            {
                TaskId = taskId,
                TaskAssignments = inComingTask.TaskAssignments,
                TaskContent = inComingTask.TaskContent,
                TaskDescription = inComingTask.TaskDescription,
                InComingDescription = description,
                InComingFinishDate = finishingDate,
                IsDelete = false,
                TaskFinishDate = inComingTask.TaskFinishDate,
                TaskStateOfUrgency = inComingTask.TaskStateOfUrgency
            };
            _taskService.Update(task);
            return RedirectToAction("Index");
        }
    }
}
