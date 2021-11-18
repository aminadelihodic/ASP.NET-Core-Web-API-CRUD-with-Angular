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
    public class RepositoryRole : RepositoryGeneric<Role>, IRepositoryRole
    {
        public RepositoryRole(IConfiguration configuration) : base(configuration)
        {

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

        public async Task<Role> GetById(string id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT id,description FROM roles WHERE id=@id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Role>(query, new { id });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
      
}
