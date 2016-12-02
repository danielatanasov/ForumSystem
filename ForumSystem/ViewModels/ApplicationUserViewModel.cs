using ForumSystem.Common.Mapping;
using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.ViewModels
{
    public class ApplicationUserViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}