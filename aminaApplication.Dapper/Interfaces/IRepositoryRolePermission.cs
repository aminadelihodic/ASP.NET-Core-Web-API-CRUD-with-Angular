using amina_WebApplication.Models;
using aminaApplication.Dapper.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace aminaApplication.Dapper.Interfaces
{
    public interface IRepositoryRolePermission: IRepositoryGeneric<RolePermission>
    {
        Task<IEnumerable<RolePermission>> GetAll(string roleId);
        Task<IEnumerable<RolePermission>> GetById(string id);
        void Delete(string roleId, string permisionId);
        void Insert(string roleId, string permissionId);
    }
}
