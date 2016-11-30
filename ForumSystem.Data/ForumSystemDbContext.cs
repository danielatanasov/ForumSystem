namespace ForumSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    //using ForumSystem.Data.Migrations;
    using ForumSystem.Models;

    public class ForumSystemDbContext : IdentityDbContext
    {
        public ForumSystemDbContext()
            : base("ForumSystemConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrackingSystemDbContext, Configuration>());
        }

        IDbSet<ApplicationUser> Users
        {
            get;
            set;
        }

        IDbSet<Post> Posts
        {
            get;
            set;
        }
        IDbSet<Category> Categories
        {
            get;
            set;
        }

        public static ForumSystemDbContext Create()
        {
            return new ForumSystemDbContext();
        }
    }
}
