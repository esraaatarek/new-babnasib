using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.Data;
using Api.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
     
        public async Task<TEntity> GetById(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }
        public async Task<TEntity> GetLastRow(Expression<Func<TEntity, bool>> predicate)
        {
            // return await _dbSet.LastOrDefaultAsync(predicate);
            return await _dbSet.Where(predicate).LastOrDefaultAsync(predicate);
        }

        public async void AddAsync(TEntity entity)
        {
           await _dbSet.AddAsync(entity);
        }
      
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllBy(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToArrayAsync();
        }
        public IQueryable<TEntity> GetAllByQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return  _dbSet.Where(predicate).AsQueryable();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> Get()
        {
            return await _dbSet.FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetSingleNoTracking(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }         

        public async Task<bool> CheckExsist(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync() == null;
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async void UpdateBy(int id)
        {
            TEntity _entity = await _dbSet.FindAsync(id);
            _context.Entry<TEntity>(_entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TEntity entity = Get(id).Result;
            _dbSet.Remove(entity);
        }

        public async Task<bool> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var result = await _context.Set<TEntity>().Where(predicate).ToListAsync();
            return result == null;
            //return Queryable.Count<TEntity>(Queryable.Where<TEntity>((IQueryable<TEntity>)this._context.Set<TEntity>(), predicate)) > 0;
        }

        public async Task<bool> Find(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result == null;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void UpdateRange<T>(IEnumerable<T> entity) where T : class
        {
            _context.Set<T>().UpdateRange(entity);
        }

        public void DeleteRange<T>(IEnumerable<T> entity) where T : class
        {
            _context.Set<T>().RemoveRange(entity);
        }

        public void AddRange<T>(IEnumerable<T> entity) where T : class
        {
            _context.Set<T>().AddRange(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }
        
        public async Task<IEnumerable<T>> GetAllBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public IQueryable<T> GetAllByQuery<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Where<T>(predicate).AsQueryable();
        }
        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }
    }
}