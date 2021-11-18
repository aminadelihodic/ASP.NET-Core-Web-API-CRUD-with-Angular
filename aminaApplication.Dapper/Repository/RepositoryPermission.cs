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
    public class RepositoryPermission : RepositoryGeneric<Permission>, IRepositoryPermission
    {
        public RepositoryPermission(IConfiguration configuration) : base(configuration)
        {

        }

        

      
    }

    
}
