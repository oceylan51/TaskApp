using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Entity
{
    public class TaskAssignment
    {
        public int TaskAssignmentId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public string UserId { get; set; }
        public bool IsDelete { get; set; }
    }
}
