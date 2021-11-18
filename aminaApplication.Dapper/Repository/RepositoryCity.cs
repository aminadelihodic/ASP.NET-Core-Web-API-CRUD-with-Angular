using amina_WebApplication.Models;
using aminaApplication.Dapper.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
namespace aminaApplication.Dapper.Repository
{
    public class RepositoryCity : RepositoryGeneric<City>,IRepositoryCity
    {
        public RepositoryCity(IConfiguration configuration):base(configuration)
        {

        }
       
    }



}


