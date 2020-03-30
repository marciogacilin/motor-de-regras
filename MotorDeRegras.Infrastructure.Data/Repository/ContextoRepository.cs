using MotorDeRegras.Domain.Entity;
using MotorDeRegras.Domain.Interface.Repository;
using MotorDeRegras.Infrastructure.Data.Interface;

namespace MotorDeRegras.Infrastructure.Data.Repository
{
    public class ContextoRepository : BaseRepository<Contexto>, IContextoRepository
    {
        public ContextoRepository(IMongoContext context) : base(context)
        {
        }
    }
}
