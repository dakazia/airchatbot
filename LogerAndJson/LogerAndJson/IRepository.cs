using System;
using System.Collections.Generic;
using System.Text;

namespace HW._15
{
    internal interface IRepository<T> where T : class
    {
        void Create(T item);
        void Delete(Guid id);
        void Update(T item);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
