using aminaApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aminaApplication.Dapper.Interfaces
{
    public interface IRepositoryUserProfile
    {
        Task<Login> GetById(int id);
        Task<IEnumerable<Login>> GetAll();
    }
}
