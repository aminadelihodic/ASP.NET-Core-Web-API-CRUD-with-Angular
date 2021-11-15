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
    public class RepositoryLogin : IRepositoryLogin
    {
        
        protected readonly IConfiguration _configuration;
        public RepositoryLogin(IConfiguration configuration)
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
        public async Task<Login> GetUsernamePassword(string username, string password)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT *
                                     FROM login WHERE username=@username and password=@password";
                    return await dbConnection.QueryFirstOrDefaultAsync<Login>(query,new { username,password });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Insert(Login login)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO login(username,email,password) VALUES(@Username,@Email,@Password)";
                    dbConnection.Execute(query, login);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Login>> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var query = @"SELECT *
                                FROM login";
                    return await dbConnection.QueryAsync<Login>(query);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
