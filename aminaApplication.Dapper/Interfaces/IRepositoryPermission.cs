using amina_WebApplication.Models;
using aminaApplication.Dapper.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aminaApplication.Dapper.Interfaces
{
    public interface IRepositoryPermission :IRepositoryGeneric<Permission>
    {
        Task<Permission> GetById(string id);
        void Delete(string id);
    }
}
