using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using Payment.Charges.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Charges.Infrastructure.Configuration
{
    public class ChargeMapping
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Charge>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdMember(x => x.Id);
                map.MapMember(x => x.DueDate).SetIsRequired(true);
                map.MapMember(x => x.RecordDate).SetIsRequired(true);
                map.MapMember(x => x.Value).SetIsRequired(true);
                map.MapMember(x => x.CPF).SetIsRequired(true);
            });
        }
    }
    public static class MongoDbInitialization
    {
        public static void Configure()
        {
            ChargeMapping.Configure();

            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
                };
            ConventionRegistry.Register("Payment.Charge.db", pack, t => true);
        }
    }
}
