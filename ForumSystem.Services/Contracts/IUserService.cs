using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services.Contracts
{
    public interface IUsersService : IService<ApplicationUser>
    {
        IQueryable<ApplicationUser> GetAll();
    }
}