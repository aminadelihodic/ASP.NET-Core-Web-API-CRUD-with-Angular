using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aminaApplication.Dapper.Interfaces
{
    public interface IRepositoryGeneric<T>
    {
        List<T> GetAll();
        void GetById(T item);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}
