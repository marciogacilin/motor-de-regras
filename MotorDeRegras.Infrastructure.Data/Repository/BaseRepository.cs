using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MotorDeRegras.Domain.Interface.Repository;
using MotorDeRegras.Infrastructure.Data.Interface;
using ServiceStack;

namespace MotorDeRegras.Infrastructure.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMongoContext _context;
        private IMongoCollection<TEntity> _dbSet;

        private void ConfigDbSet()
        {
            _dbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public BaseRepository(IMongoContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity obj)
        {
            ConfigDbSet();
            _context.AddCommand(() => _dbSet.InsertOneAsync(obj));
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            ConfigDbSet();
            IAsyncCursor<TEntity> _reg = await _dbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return _reg.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            ConfigDbSet();
            var _regs = await _dbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return _regs.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            ConfigDbSet();
            _context.AddCommand(() => _dbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }        
    }
}
