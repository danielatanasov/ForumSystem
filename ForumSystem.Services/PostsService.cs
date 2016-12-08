using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSystem.Data;
using ForumSystem.Models;
using ForumSystem.Services.Contracts;

namespace ForumSystem.Services
{
    public class PostsService : BaseService<Post>, IPostsService
    {
        public PostsService(IForumSystemData data) : base(data)
        {
        }
        public ICollection<Post> GetAllById(int id)
        {
            var posts = base.GetAll().Where(c => c.Category.Id == id).ToList();
            return posts;
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

    }
}
