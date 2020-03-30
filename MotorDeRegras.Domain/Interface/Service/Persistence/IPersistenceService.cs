using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorDeRegras.Domain.Interface.Service.Persistence
{
    public interface IPersistenceService<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        void Update(TEntity obj);
    }
}
