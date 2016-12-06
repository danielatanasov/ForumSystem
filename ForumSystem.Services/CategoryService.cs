using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem.Models;
using ForumSystem.Data;

namespace ForumSystem.Services
{
    public class PostService : BaseService<Post>, ICategoryService
    {
        public PostService(IForumSystemData data)
            : base(data)
        {
        }

        public override IQueryable<Post> GetAll()
        {
            return base.GetAll().OrderByDescending(p => p.CreatedOn);
        }

        public override void Add(Post entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }

        IQueryable<Category> ICategoryService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}