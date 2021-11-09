using amina_WebApplication.Models;
using aminaApplication.Dapper.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace aminaApplication.Dapper.Repository
{
    public class RepositoryRolePermission : IRepositoryGeneric<RolePermission>, IRepositoryRolePermission
    {

        protected readonly IConfiguration _configuration;
        public RepositoryRolePermission(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(_configuration.GetConnectionString("Database"));
            }

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string roleId, string permissionId)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM role_permissions WHERE role_id=@roleId and permission_id=@permissionId";
                    dbConnection.Execute(query, new { roleId, permissionId });
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<RolePermission>> GetAll(string roleId)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM role_permissions WHERE role_id=@roleId";
                    return await dbConnection.QueryAsync<RolePermission>(query, new { roleId });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<IEnumerable<RolePermission>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RolePermission>> GetById(string id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT role_id as role_id,permission_id as permission_id FROM role_permissions WHERE role_id=@id";
                    return await dbConnection.QueryAsync<RolePermission>(query,new { id});
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<RolePermission> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(RolePermission rolePermission)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO role_permissions(role_id,permission_id) VALUES(@RoleId,@PermissionId)";
                    dbConnection.Execute(query, rolePermission);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Update(RolePermission role)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE role_permissions SET permission_id=@PermissionId WHERE role_id=@RoleId";
                    dbConnection.Execute(query, role);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
