using System.Collections.Generic;
using qweMVC.Models;

namespace qweMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            var role1 = new Role { RoleName = "Admin" };
            var role2 = new Role { RoleName = "User" };

            var user1 = new User { Username = "admin", Email = "admin@ymail.com", Password = "123456", Roles = new List<Role>() };
            var user2 = new User { Username = "user1", Email = "user1@ymail.com", Password = "123456", Roles = new List<Role>() };
            user1.Roles.Add(role1);
            user2.Roles.Add(role2);
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Comments.RemoveRange(context.Comments);
        }
    }
}
