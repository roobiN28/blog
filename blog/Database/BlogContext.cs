using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using blog.entity;
using blog.Models;

namespace blog.Database
{
  
    public class BlogContext :DbContext
    {
        public BlogContext() : base("BlogContext")
        {
//            CreateDatabaseIfNotExists
//                DropCreateDatabaseAlways
//                DropCreateDatabaseIfModelChanges
            System.Data.Entity.Database.SetInitializer<BlogContext>(new DropCreateDatabaseIfModelChanges<BlogContext>());
            //System.Data.Entity.Database.SetInitializer<BlogContext>(new DropCreateDatabaseAlways<BlogContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}