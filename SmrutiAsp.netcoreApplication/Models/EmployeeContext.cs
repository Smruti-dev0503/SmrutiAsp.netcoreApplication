using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmrutiAsp.netcoreApplication.Models
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<User> User { get; set; }
    }
}
