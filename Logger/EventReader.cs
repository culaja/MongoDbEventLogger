using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using static Newtonsoft.Json.JsonConvert;

namespace Logger
{
    public sealed class EventReader
    {
        private readonly IMongoCollection<EventLog> _eventLogCollection = new DatabaseContext("mongodb://localhost:27017/").GetCollectionFor<EventLog>();
        
        public IReadOnlyList<object> ReadAll() => _eventLogCollection
            .AsQueryable().ToList()
            .Select(eventLog => DeserializeObject(eventLog.SerializedContent, Type.GetType(eventLog.ObjectType)))
            .ToList();
    }
}