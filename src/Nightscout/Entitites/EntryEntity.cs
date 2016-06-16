using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Nightscout.Entitites
{
    public class EntryEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("date")]
        [BsonRepresentation(BsonType.Int64)]
        public long Date { get; set; }

        [BsonElement("dateString")]
        public string DateString { get; set; }

        [BsonElement("device")]
        public string Device { get; set; }

        [BsonElement("direction")]
        public string Direction { get; set; }

        [BsonElement("filtered")]
        public double Filtered { get; set; }

        [BsonElement("noise")]
        [BsonRepresentation(BsonType.Int32)]
        public int Noise { get; set; }

        [BsonElement("rssi")]
        [BsonRepresentation(BsonType.Int32)]
        public int Rssi { get; set; }

        [BsonElement("sgv")]
        [BsonRepresentation(BsonType.Int32)]
        public int Sgv { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("sysTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc, Representation = BsonType.String)]
        public DateTime SystemTime { get; set; }

        [BsonElement("unfiltered")]
        public double Unfiltered { get; set; }
    }
}