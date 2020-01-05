using EmployeeApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Configuration;

namespace EmployeeApp.EntityFramework
{
    public class EmployeeDataContext: System.Data.Entity.DbContext
    {
        public EmployeeDataContext():base("Server=.\\SQLEXPRESS;Database=EmployeesDataBase;Trusted_Connection=True;")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EmployeeDataContext>());
        }
        public System.Data.Entity.DbSet<Employee> Employees { get; set; }
        
    }

}
