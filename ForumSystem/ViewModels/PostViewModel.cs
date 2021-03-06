﻿using ForumSystem.Common.Mapping;
using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.ViewModels
{
    public class PostViewModel : IMapFrom<Post>, IMapTo<Post>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Content { get; set; }
        public ApplicationUserViewModel Author { get; set; }
        public string AuthorId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public CategoryViewModel Category { get; set; }
        public int CategoryId { get; set; }
    }
}