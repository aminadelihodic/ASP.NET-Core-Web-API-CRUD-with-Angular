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
    public class RepositoryRole : IRepositoryGeneric<Role>, IRepositoryRole
    {

        protected readonly IConfiguration _configuration;
        public RepositoryRole(IConfiguration configuration)
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
                    string query = @"DELETE FROM roles WHERE id=@id";
                    dbConnection.Execute(query, new { id });
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT id,description FROM roles";
                    return await dbConnection.QueryAsync<Role>(query);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Task<Role> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> GetById(string id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT id,description FROM permissions WHERE id=@id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Role>(query, new { id });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Insert(Role role)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO roles(id,description) VALUES(@Id,@Description)";
                    dbConnection.Execute(query, role);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Role role)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE roles SET description=@Description WHERE id=@Id";
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
