using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT_project_2021.Models.repo
{
    public class AppointmentContext : DbContext
    {
        public DbSet<AppointmentModel> Appointments { get; set; }

        public DbSet<CustomersModel> Customers { get; set; }

        public DbSet<UserContext> Users { get; set; }

        public AppointmentContext() : base("DefaultConnection") { }

        public static AppointmentContext Create()
        {
            return new AppointmentContext();
        }
    }
}