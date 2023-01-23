using Microsoft.EntityFrameworkCore;

namespace MVCDay2.Models
{
    public class CompanyDbContext:DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Dependent> Dependents { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Emp_Proj> Emp_Projs { get; set; }
        public virtual DbSet<Dept_loc> Dept_Locs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Company;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp_Proj>().HasKey("Emp_SSN", "Proj_Id");
            modelBuilder.Entity<Dept_loc>().HasKey("Dept_id", "Locatoin");
            modelBuilder.Entity<Department>().HasOne(c => c.employee).WithOne(c => c.department);
            modelBuilder.Entity<Department>().HasMany(c => c.Employees).WithOne(c => c.manage);


        }
    }
}
