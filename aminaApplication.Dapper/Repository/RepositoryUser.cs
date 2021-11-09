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
    public class RepositoryUser : IRepositoryGeneric<User>,IRepositoryUser
    {
        protected readonly IConfiguration _configuration;
        public RepositoryUser(IConfiguration configuration)
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
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM users WHERE id=@id";
                    dbConnection.Execute(query, new { id });
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var query = @"SELECT U.*, C.name as city_name
                                FROM users AS U JOIN cities AS C ON city_id=C.id";
                    return await dbConnection.QueryAsync<User>(query);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT *
                                FROM users WHERE id=@id";
                    return await dbConnection.QueryFirstOrDefaultAsync<User>(query, new { id });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Insert(User user)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO users(first_name,last_name,username,password_hash,email,phone_number,city_id,role_id) VALUES(@FirstName,@LastName,@Username,@PasswordHash,@Email,@PhoneNumber,@CityId,@RoleId)";
                    dbConnection.Execute(query, user);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(User user)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE users SET first_name=@FirstName WHERE id=@Id";
                    dbConnection.Execute(query, user);
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
