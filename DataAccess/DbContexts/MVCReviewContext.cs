using System.Data.Entity;
using Model;

namespace DataAccess.DbContexts
{
    public class MvcReviewContext:DbContext
    {
        public MvcReviewContext() : base("name=MVCReview")
        {
            Database.SetInitializer<MvcReviewContext>(null);
        }

        public virtual DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Table Name Mapping
            modelBuilder.Entity<Employee>().ToTable("Employee");
            #endregion

            #region Column Name Mapping
            modelBuilder.Entity<Employee>().Property(e => e.Name).HasColumnName("EmployeeName");
            modelBuilder.Entity<Employee>().Property(e => e.Salary).HasPrecision(18, 2);
            #endregion

            #region Ignore Columns
            modelBuilder.Entity<Employee>().Ignore(x => x.Age);
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
