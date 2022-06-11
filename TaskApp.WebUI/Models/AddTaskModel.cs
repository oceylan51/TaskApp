using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.WebUI.Models
{
    public class AddTaskModel
    {
        public int TaskId { get; set; }
        [Required(ErrorMessage = "Content cannot be left blank")]
        public string TaskContent { get; set; }
        [Required(ErrorMessage = "State Of Urgency cannot be left blank")]
        public string TaskStateOfUrgency { get; set; }
        [Required(ErrorMessage = "Finish date cannot be left blank")]
        public DateTime TaskFinishDate { get; set; }
        public bool IsDelete { get; set; }

    }
}
