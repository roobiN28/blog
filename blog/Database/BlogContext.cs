using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using blog.Models;

namespace blog.Database
{
  
    public class BlogContext :DbContext
    {
        public BlogContext() : base("BlogContext")
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}