using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aminaApplication.Dapper.Repository
{
    public interface IRepositoryGeneric<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(int id);
    }
}
