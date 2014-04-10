namespace CCC2014.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using CCC2014.Models;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<CCC2014.Models.CCC2014DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }



        protected override void Seed(CCC2014DbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.People.AddOrUpdate(
            //  p => p.FullName,
            //  new Person { FullName = "Andrew Peters" },
            //  new Person { FullName = "Brice Lambson" },
            //  new Person { FullName = "Rowan Miller" }
            //);

            WebSecurity.InitializeDatabaseConnection("CCC2014Connection", "UserProfile", "UserId", "UserName", true);

            #region Roles
            if (!Roles.RoleExists("User"))
                Roles.CreateRole("User");

            if (!Roles.RoleExists("OC Unit"))
                Roles.CreateRole("OC Unit");

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!Roles.RoleExists("Contingent Commander"))
                Roles.CreateRole("Contingent Commander");

            if (!Roles.RoleExists("Media"))
                Roles.CreateRole("Media");
            #endregion

            #region Users
            if (!WebSecurity.UserExists("mjavacam"))
                WebSecurity.CreateUserAndAccount("mjavacam", "password");
            if (!Roles.GetRolesForUser("mjavacam").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "mjavacam" }, new[] { "Administrator" });
            #endregion
        }
    }
}
