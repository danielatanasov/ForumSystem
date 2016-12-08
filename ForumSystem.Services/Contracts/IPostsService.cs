using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services.Contracts
{
    public interface IPostsService : IService<Post>
    {
        IQueryable<Post> GetAll();

        ICollection<Post> GetAllById(int id);
    }
}
