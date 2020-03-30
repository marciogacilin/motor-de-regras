using MotorDeRegras.Domain.Entity;
using MotorDeRegras.Domain.Interface.Repository;
using MotorDeRegras.Domain.Interface.Service;

namespace MotorDeRegras.Domain.Service.Persistence
{
    public class ContextoPersistenceService : BasePersistenceService<Contexto>, IContextoPersistenceService
    {
        public ContextoPersistenceService(IContextoRepository repository) : base(repository)
        {            
        }
    }
}
