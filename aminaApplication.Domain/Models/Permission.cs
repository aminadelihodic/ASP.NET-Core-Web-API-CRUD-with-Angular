﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace amina_WebApplication.Models
{
    [Table("permissions")]
    public class Permission : IEntity<string>
    {
        [Key]
        

        [Column("id")]
        public string Id { get; set; }
        [Column("description")]
        public string Description { get; set; }

        public bool IsTransient()
        {
            return this.Id == default(string);
        }
    }
}
