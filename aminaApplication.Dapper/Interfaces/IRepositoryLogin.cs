using aminaApplication.Dapper.Repository;
using aminaApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aminaApplication.Dapper.Interfaces
{
    public interface IRepositoryLogin
    {
        void Insert(Login item);
        Task<IEnumerable<Login>> GetAll();
        Task<Login> GetUsernamePassword(string username,string password);
    }
}
