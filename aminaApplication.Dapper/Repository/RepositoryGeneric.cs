using aminaApplication.Dapper.Interfaces;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper.FastCrud;
using System.Linq;
using amina_WebApplication.Models;
using System.Threading.Tasks;

namespace aminaApplication.Dapper.Repository
{
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        public readonly IConfiguration _configuration;
        public RepositoryGeneric(IConfiguration configuration)
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

        public void Delete(T item)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Delete<T>(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<T> GetAll()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    List<T> t = dbConnection.Find<T>().ToList();
                    return t;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void GetById(T item)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Get<T>(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Insert(T item)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Insert<T>(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(T item)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    dbConnection.Update<T>(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}