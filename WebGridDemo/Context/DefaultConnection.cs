using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebGridDemo.Models;

namespace WebGridDemo.Context
{
    public class DefaultConnection : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}