using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MotorDeRegras.Infrastructure.Data.Interface;

namespace MotorDeRegras.Infrastructure.Data.Context
{
    public class MongoContext : IMongoContext
    {
        private IMongoDatabase _dataBase;
        private IClientSessionHandle _session;
        private MongoClient _mongoClient;
        private readonly List<Func<Task>> _commands;
        private readonly IConfiguration _configuration;

        private void ConfigureMongo()
        {
            if (_mongoClient != null)
                return;

            _mongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);

            _dataBase = _mongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);

        }

        public MongoContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _commands = new List<Func<Task>>();
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public void Dispose()
        {
            _session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();
            return _dataBase.GetCollection<T>(name);
        }

        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (_session = await _mongoClient.StartSessionAsync())
            {
                _session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await _session.CommitTransactionAsync();
            }

            return _commands.Count;
        }
    }
}
