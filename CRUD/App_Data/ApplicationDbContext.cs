using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CRUD.Models;


namespace CRUD.App_Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}