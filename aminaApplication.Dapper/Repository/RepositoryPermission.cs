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
    public class RepositoryPermission : IRepositoryGeneric<Permission>, IRepositoryPermission
    {

        protected readonly IConfiguration _configuration;
        public RepositoryPermission(IConfiguration configuration)
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

        public void Delete(string id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM permissions WHERE id=@id";
                    dbConnection.Execute(query, new { id });
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Permission>> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT id,description FROM permissions";
                    return await dbConnection.QueryAsync<Permission>(query);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task<Permission> GetById(string id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT id,description FROM permissions WHERE id=@id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Permission>(query, new { id });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<Permission> GetById(int id)
        {
            throw new NotImplementedException();
        }



        public void Insert(Permission permission)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO permissions(id,description) VALUES(@Id,@Description)";
                    dbConnection.Execute(query, permission);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Permission permission)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE permissions SET description=@Description WHERE id=@Id";
                    dbConnection.Execute(query, permission);
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
