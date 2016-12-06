﻿using ForumSystem.Data;
using ForumSystem.Data.Repositories;
using ForumSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services
{
    public class BaseService<T> : IService<T> where T : class
    {
        private IRepository<T> repository;
        private IForumSystemData data;

        public BaseService(IForumSystemData data)
        {
            this.Data = data;
            this.repository = data.GetRepository<T>();
        }
        protected IForumSystemData Data { get; private set; }


        public virtual IQueryable<T> GetAll()
        {
            return this.repository.All();
        }

        public virtual T Find(object id)
        {
            return this.repository.Find(id);
        }

        public virtual void Add(T entity)
        {
            this.repository.Add(entity);
            this.repository.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            this.repository.Update(entity);
            this.repository.SaveChanges();
        }

        public virtual void Delete(object id)
        {
            this.repository.Delete(id);
            this.repository.SaveChanges();
        }

        public void SaveChanges()
        {
            this.repository.SaveChanges();
        }
    }
}