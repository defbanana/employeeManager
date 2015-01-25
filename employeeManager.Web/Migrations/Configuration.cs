using employeeManager.Domain;
using System.Web.Security;

namespace employeeManager.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<employeeManager.Web.Infastructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(employeeManager.Web.Infastructure.DepartmentDb context)
        {
            context.Departments.AddOrUpdate(d => d.Name,
                    new Department() { Name = "Engineering" },
                    new Department() { Name = "Sales" },
                    new Department() { Name = "Shipping" },
                    new Department() { Name = "Human Reources" }
                );

            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile",
                "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if(!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if(membership.GetUser("jpokora", false) == null)
            {
                membership.CreateUserAndAccount("jpokora", "abcde");
            }
            if(!roles.GetRolesForUser("jpokora").Contains("Admin"))
            {
                roles.AddUsersToRoles( new[] { "jpokora" }, new[] {"Admin"});
            }
        }
    }
}
