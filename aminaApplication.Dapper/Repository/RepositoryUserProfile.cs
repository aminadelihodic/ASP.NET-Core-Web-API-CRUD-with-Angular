using amina_WebApplication.Models;
using aminaApplication.Dapper.Interfaces;
using aminaApplication.Domain.Models;
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
    public class RepositoryUserProfile : IRepositoryUserProfile
    {
        protected readonly IConfiguration _configuration;
        public RepositoryUserProfile(IConfiguration configuration)
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

        public async Task<IEnumerable<Login>> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var query = @"SELECT username,email
                                FROM login";
                    return await dbConnection.QueryAsync<Login>(query);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Login> GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT *
                                FROM login WHERE id=@id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Login>(query, new { id });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
