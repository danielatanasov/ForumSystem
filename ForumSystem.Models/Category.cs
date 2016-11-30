using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Models
{
    public class Category : BaseModel
    {
        public string  Title { get; set; }
        public string ShortDescription { get; set; }
        public virtual ApplicationUser LastModifiedBy { get; set; }
        public string LastModifiedById { get; set; }
    }
}
