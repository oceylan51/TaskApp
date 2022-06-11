﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Data.Abstract
{
    public interface IRepository<T>
    {
        void Create(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
