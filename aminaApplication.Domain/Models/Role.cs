using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace amina_WebApplication.Models
{
    [Table("roles")]
    public class Role
    {

        [Column("id")]
        public string Id { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
