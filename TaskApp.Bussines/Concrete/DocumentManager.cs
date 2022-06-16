using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Bussines.Abstract;
using TaskApp.Data.Abstract;
using TaskApp.Entity;

namespace TaskApp.Bussines.Concrete
{
    public class DocumentManager : IDocumentService
    {
        private IDocumentRepository _documentRepository;

        public DocumentManager(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public void AddDeletedBack(int id)
        {
            _documentRepository.AddDeletedBack(id);
        }

        public void Create(Document entity)
        {
            _documentRepository.Create(entity);
        }

        public void DocumentDelete(int id)
        {
            _documentRepository.DocumentDelete(id);
        }

        public List<Document> GetAll()
        {
            return _documentRepository.GetAll();
        }

        public Document GetById(int id)
        {
            return _documentRepository.GetById(id);
        }

        public List<Document> GetDeletedDocument()
        {
            return _documentRepository.GetDeletedDocument();
        }

        public List<Document> GetDocumentsAddedById(string Id)
        {
            return _documentRepository.GetDocumentsAddedById(Id);
        }

        public List<Document> GetNotDeletedDocument()
        {
            return _documentRepository.GetNotDeletedDocument();
        }

        public void Update(Document entity)
        {
            _documentRepository.Update(entity);
        }
    }
}
