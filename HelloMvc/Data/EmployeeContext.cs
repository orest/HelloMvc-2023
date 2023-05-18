using HelloMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Data {
    public class EmployeeContext : DbContext {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) {

        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().HasKey(p => p.EmployeeId);
            //modelBuilder.Entity<Employee>().Property(p => p.FirstName).HasMaxLength(200);

            base.OnModelCreating(modelBuilder);
        }
    }
}


