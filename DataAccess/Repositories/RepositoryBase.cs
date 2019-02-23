using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected SpotifyDBContext RepositoryContext { get; set; }

        protected RepositoryBase(SpotifyDBContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public virtual IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public int Save()
        {
            return this.RepositoryContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await this.RepositoryContext.SaveChangesAsync();
        }
    }
}
