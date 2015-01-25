using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using employeeManager.Domain;
using System.Data.Entity;

namespace employeeManager.Web.Infastructure
{
    public class DepartmentDb :  DbContext, IDepartmentDataSource
    {
        
        public DepartmentDb() : base("DefaultConnection")
        {

        }

        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        void IDepartmentDataSource.Save()
        {
            SaveChanges();
        }

        IQueryable<Employee> IDepartmentDataSource.Employees
        {
            get { return Employees; }
        }

        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }
    }
}