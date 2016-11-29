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
    }
}