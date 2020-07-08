using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Domain
{
    public class EmployeesDataContext : DbContext
    {
        public EmployeesDataContext(DbContextOptions<EmployeesDataContext> options): base(options)
        {

        }
        // Julie Lehrman - pluralsight
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Employee>().Property(p => p.FirstName).HasMaxLength(50);

            modelBuilder.Entity<Employee>().HasData(
                    new Employee {  Id =1, FirstName="Sue", LastName="Smith", Department="CEO", Active=true, Salary=150000},
                    new Employee {  Id =2, FirstName="Bob", LastName="Maple", Department="DEV", Active=true, Salary=80000},
                    new Employee {  Id=3, FirstName="Sean", LastName="Carlin", Department="DEV", Active=false, Salary = 0}
                );
        }
    }
}
