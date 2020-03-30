using System;
using System.Threading.Tasks;

namespace MotorDeRegras.Domain.Interface.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
