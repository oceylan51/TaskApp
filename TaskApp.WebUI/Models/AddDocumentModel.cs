using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApp.WebUI.Models
{
    public class AddDocumentModel
    {
        public int DocumentId { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentTitle { get; set; }
        public bool IsDelete { get; set; }
    }
}
