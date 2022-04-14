using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IT_project_2021.Models.repo
{
    public class UserContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<ExercisesModel> Exercises { get; set; }


        public UserContext() : base("DefaultConnection") { }

        public static UserContext Create()
        {
            return new UserContext();
        }
    }
}