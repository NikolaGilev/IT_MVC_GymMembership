using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT_project_2021.Models
{
    public class CustomersContext : DbContext
    {
        public DbSet<CustomersModel> Customers { get; set; }



        public CustomersContext() : base("DefaultConnection") { }

        public static CustomersContext Create()
        {
            return new CustomersContext();
        }
    }
}