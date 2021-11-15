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
    public class RepositoryCity : RepositoryGeneric<City>, IRepositoryCity
    {
        protected readonly IConfiguration _configuration;
        public RepositoryCity(IConfiguration configuration)
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
                    var query = @"DELETE FROM cities WHERE id=@id";
                    dbConnection.Execute(query, new { id });
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var query = @"SELECT c.id,c.name,c.country_id as countryid,coun.name as CountryName FROM cities as c 
                                  INNER JOIN countries as coun 
                                  ON c.country_id=coun.id";
                    return await dbConnection.QueryAsync<City>(query);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<City> GetById(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT id,name,country_id FROM cities WHERE id=@id";
                    return await dbConnection.QueryFirstOrDefaultAsync<City>(query, new { id });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Insert(City city)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    var query = @"INSERT INTO cities(name,country_id) VALUES(@Name,@CountryId)";
                    dbConnection.Execute(query, city);
                    dbConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(City city)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE cities SET name=@Name WHERE id=@Id";
                    dbConnection.Execute(query, city);
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
