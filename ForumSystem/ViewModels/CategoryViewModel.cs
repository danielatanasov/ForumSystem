using ForumSystem.Common.Mapping;
using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.ViewModels
{
    public class CategoryViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public ApplicationUser LastModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}