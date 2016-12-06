namespace ForumSystem.Data
{
    using ForumSystem.Data.Repositories;
    using ForumSystem.Models;

    public interface IForumSystemData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }
        IRepository<Post> Posts
        {
            get;
        }
        IRepository<Category> Categories
        {
            get;
        }
        IRepository<T> GetRepository<T>() where T : class;
    }
}