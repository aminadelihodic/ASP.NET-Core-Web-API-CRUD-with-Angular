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
    public class RepositoryCountry : IRepositoryGeneric<Country>, IRepositoryCountry
    {
        protected readonly IConfiguration _configuration;
        public RepositoryCountry(IConfiguration configuration)
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
                    string query = @"DELETE FROM countries WHERE id=@id";
                    dbConnection.Execute(query, new { id });
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT id,name FROM countries";
                    return await dbConnection.QueryAsync<Country>(query);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Country> GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT id,name FROM countries WHERE id=@id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Country>(query, new { id });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Insert(Country country)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var query = @"INSERT INTO countries(name) VALUES(@Name)";
                    dbConnection.Execute(query, country);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Update(Country country)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE countries SET name=@Name WHERE id=@Id";
                    dbConnection.Execute(query, country);
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
