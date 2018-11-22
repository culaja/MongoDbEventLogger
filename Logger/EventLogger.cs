using MongoDB.Bson;
using MongoDB.Driver;
using static Newtonsoft.Json.JsonConvert;

namespace Logger
{
    public sealed class EventLogger
    {
        private readonly IMongoCollection<EventLog> _eventLogCollection = new DatabaseContext("mongodb://localhost:27017/").GetCollectionFor<EventLog>();
        
        public void Log(object data)
        {
            _eventLogCollection.InsertOne(new EventLog
            {
                Id = ObjectId.GenerateNewId(),
                ObjectType = data.GetType().FullName,
                SerializedContent = SerializeObject(data)
            });
        }
    }
}