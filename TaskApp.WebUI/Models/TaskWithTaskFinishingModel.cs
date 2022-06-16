using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.WebUI.Models
{
    public class TaskWithTaskFinishingModel
    {
        public TaskApp.Entity.Task Task { get; set; }
        public TaskAssignmentFinishingModel TaskAssignmentFinishingModel { get; set; }
    }
}
