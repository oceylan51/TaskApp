namespace TaskApp.Entity
{
    public class Document
    {
        public int DocumentId { get; set; }
        public int TaskId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDelete { get; set; }


    }
}