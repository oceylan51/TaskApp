using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Entity;

namespace TaskApp.Data.Abstract
{
    public interface IDocumentRepository : IRepository<Document>
    {
        void DocumentDelete(int id);
        List<Document> GetNotDeletedDocument();
        List<Document> GetDeletedDocument();
        void AddDeletedBack(int id);
        List<Document> GetDocumentsAddedById(string Id);
    }
}
