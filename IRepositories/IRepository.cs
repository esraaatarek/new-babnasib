using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;

namespace Api.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<bool> CheckExsist(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(int id);
        void Add(TEntity entity);
        void AddRange(List<TEntity> entity);
        void Update(TEntity entity);
        void UpdateRange<T>(IEnumerable<T> entity) where T : class;
        void UpdateBy(int id);
        void Delete(int id);
        void DeleteRange<T>(IEnumerable<T> entity) where T : class;
        void AddRange<T>(IEnumerable<T> entity) where T : class;
        void RemoveRange(IEnumerable<TEntity> entity);
        Task<bool> Find(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Find(int id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}