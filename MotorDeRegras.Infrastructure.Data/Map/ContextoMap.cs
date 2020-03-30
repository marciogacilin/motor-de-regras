using MongoDB.Bson.Serialization;
using MotorDeRegras.Domain.Entity;

namespace MotorDeRegras.Infrastructure.Data.Map
{
    public class ContextoMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Contexto>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.Codigo).SetIsRequired(true);
                map.MapMember(x => x.Descricao).SetIsRequired(true);
            });
        }
    }
}
