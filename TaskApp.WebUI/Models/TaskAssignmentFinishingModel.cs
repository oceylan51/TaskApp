using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.WebUI.Models
{
    public class TaskAssignmentFinishingModel
    {

        public int TaskId { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime FinishingDate { get; set; }
        public int[] DocumnetsIds { get; set; }
    }
}
