using AutoMapper;
using ForumSystem.Common.Mapping;
using ForumSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumSystem.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
            :this(new ForumSystemData())
        {

        }
        public BaseController(IForumSystemData data)
        {
            this.Data = data;
        }
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
        protected IForumSystemData Data{ get; private set; }
    }
}