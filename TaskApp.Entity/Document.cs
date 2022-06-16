using System.Collections.Generic;

namespace TaskApp.Entity
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string ImageUrl { get; set; }
        public string DocumentTitle { get; set; }
        public string AddedById { get; set; }
        public bool IsDelete { get; set; }
        public List<TaskWithDocument> TaskWithDocuments { get; set; }
    }
}