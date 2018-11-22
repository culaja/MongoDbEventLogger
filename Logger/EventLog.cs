using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Logger
{
    internal sealed class EventLog
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public string ObjectType { get; set; }
        
        public string SerializedContent { get; set; }
    }
}