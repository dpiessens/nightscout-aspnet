using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nightscout.Entitites
{
    [BsonIgnoreExtraElements(true)]
    public class TreatmentEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("eventType")]
        public string EventType { get; set; }

        [BsonElement("timestamp")]
        public string Timestamp { get; set; }
    }
}