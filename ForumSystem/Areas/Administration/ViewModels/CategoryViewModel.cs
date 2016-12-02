using ForumSystem.Common.Mapping;
using ForumSystem.Models;
using ForumSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Areas.Administration.ViewModels
{
    public class CategoryViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id  { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public ApplicationUserViewModel LastModifiedBy { get; set; }
        [Required]
        public string LastModifiedById { get; set; }
        public SelectList Users { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}