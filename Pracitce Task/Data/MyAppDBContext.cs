using Microsoft.EntityFrameworkCore;
using Pracitce_Task.Models;

namespace Pracitce_Task.Data
{
    public class MyAppDBContext : DbContext
    {
        public MyAppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employees> EMPLOYEE { get; set; }
        public DbSet<Department> DEPARTMENT { get; set; }

    }
}
