using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Data.Abstract;
using TaskApp.Entity;

namespace TaskApp.Data.Concrete.EF
{
    public class EfCoreDocumentRepository : EfCoreGenericRepository<TaskAppContext, Document>, IDocumentRepository
    {
        public void AddDeletedBack(int id)
        {
            using (var context = new TaskAppContext())
            {
                var document = context.Documents.Find(id);
                document.IsDelete = false;
                context.Documents.Update(document);
                context.SaveChanges();
            }
        }

        public void DocumentDelete(int id)
        {
            using (var context = new TaskAppContext())
            {
                var document = context.Documents.Find(id);
                document.IsDelete = true;
                context.Documents.Update(document);
                context.SaveChanges();
            }
        }

        public List<Document> GetDeletedDocument()
        {
            using (var context = new TaskAppContext())
            {
                return context.Documents.Where(x => x.IsDelete == true).ToList();
            }
        }

        public List<Document> GetDocumentsAddedById(string Id)
        {
            using (var context = new TaskAppContext())
            {
                return context.Documents.Where(x => x.AddedById == Id).ToList();
            }
        }

        public List<Document> GetNotDeletedDocument()
        {
            using (var context = new TaskAppContext())
            {
                return context.Documents.Where(x => x.IsDelete == false).ToList();
            }
        }
    }
}
