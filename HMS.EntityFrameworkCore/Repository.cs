﻿using HMS.Application.Shared.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HMS.EntityFrameworkCore
{
   public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly HMSDbContext _dbContext;
        internal DbSet<TEntity> dbSet;

        public Repository(HMSDbContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public async Task<TEntity> GetById(long id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
                        //.AsNoTracking()
                        //.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<long> Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<long> Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<long> Delete(TEntity entity)
        {
            //var entity = await GetById(id);
            // _dbContext.Set<TEntity>().Remove(entity);
            
            _dbContext.Set<TEntity>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<long> AddRange(List<TEntity> entity)
        {
            _dbContext.AddRange(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
