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
    public class UsersService : BaseService<ApplicationUser>, IUsersService
    {
        public UsersService(IForumSystemData data)
            : base(data)
        {
        }

    }
}