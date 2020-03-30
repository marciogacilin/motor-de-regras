using MotorDeRegras.Domain.Interface.Repository;
using MotorDeRegras.Domain.Interface.Service.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorDeRegras.Domain.Service.Persistence
{
    public abstract class BasePersistenceService<TEntity> : IPersistenceService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public BasePersistenceService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
