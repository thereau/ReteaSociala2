using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ReteaSocialaMDS.Models;

namespace ReteaSocialaMDS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReteaSocialaMDS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ReteaSocialaMDS.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            /*var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(
                    new ApplicationDbContext()));
            var user1 = new ApplicationUser
            {
                UserName = "robert.thereau@gmail.com",
                Email = "robert.thereau@gmail.com",
                FirstName = "Robert",
                LastName = "Sandu",
                AdressName = "Bla bla bla numarul random",
                TwitterHandle = "thereau",
                BirthDate = DateTime.Now,
                AccountCreation = DateTime.Now,
            };
            
            manager.Create(user1, "1234--Aa");
            var user2 = new ApplicationUser
            {
                UserName = "robert_thereau@yahoo.com",
                Email = "robert_thereau@yahoo.com",
                FirstName = "Robert",
                LastName = "Sandu",
                AdressName = "Bla bla bla numarul random",
                TwitterHandle = "thereau",
                BirthDate = DateTime.Now,
                AccountCreation = DateTime.Now,
            };
            manager.Create(user1, "1234--Aa");*/

        }
    }
}
