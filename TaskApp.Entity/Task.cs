using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Entity
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskContent { get; set; }
        public string TaskStateOfUrgency { get; set; }
        public DateTime TaskFinishDate { get; set; }
        public List<Document> Documents { get; set; }
        public bool IsDelete { get; set; }

    }
}
