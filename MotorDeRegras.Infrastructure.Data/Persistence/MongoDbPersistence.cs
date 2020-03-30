using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MotorDeRegras.Infrastructure.Data.Map;

namespace MotorDeRegras.Infrastructure.Data.Persistence
{
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            //Incluir os objeto de mapeamento das entidades
            ContextoMap.Configure();

            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("MotorDeRegrasConventions", pack, t => true);
        }
    }
}
