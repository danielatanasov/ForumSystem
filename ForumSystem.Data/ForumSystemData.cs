namespace ForumSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using ForumSystem.Data.Repositories;
    using ForumSystem.Models;

    public class ForumSystemData : IForumSystemData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public ForumSystemData()
            : this(new ForumSystemDbContext())
        {
        }

        public ForumSystemData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>) this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
