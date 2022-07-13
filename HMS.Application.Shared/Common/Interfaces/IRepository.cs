using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(long id);

        Task<long> Create(TEntity entity);

        Task<long> Update(TEntity entity);

        Task<long> Delete(TEntity entity);
        Task<long> AddRange(List<TEntity> entity);
        Task<long> UpdateRange(List<TEntity> entity);
    }        
}
