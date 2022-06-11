using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Bussines.Abstract
{
    public interface IRepositoryService<T>
    {
        void Create(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
