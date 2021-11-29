using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Driver
{
    public abstract class MongoBase
    {
        private readonly MongoClient mongoClient;
        protected MongoBase(string host, string account, string password)
        {
            string connectionString = "mongodb://" + account + ":" + password + "@" + host + "/?safe=true&maxPoolSize=3000";
            this.mongoClient = new MongoClient(connectionString);
        }
        private IMongoDatabase GetDatabase(string databaseName)
        {
            return this.mongoClient.GetDatabase(databaseName);
        }
        private protected IMongoCollection<T> GetCollection<T>(string dataBaseName, string collectionName = null, string separator = null)
        {
            IMongoDatabase database = this.GetDatabase(dataBaseName);
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                collectionName = typeof(T).GetClassName(separator);
            }
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName);
            return collection;
        }
    }
}
