using MongoDB.Bson;
using MongoDB.Driver;

namespace Logger
{
    public sealed class DatabaseContext
    {
        private readonly IMongoDatabase _maintenanceDatabase;

        public DatabaseContext(string connectionString)
        {
            var mongoClient = new MongoClient(connectionString);
            _maintenanceDatabase = mongoClient.GetDatabase("LocalEventing");
        }

        public IMongoCollection<T> GetCollectionFor<T>()
            => _maintenanceDatabase.GetCollection<T>(typeof(T).Name);
    }
}