using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MotorDeRegras.Infrastructure.Data.Interface
{
    public interface IMongoContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
