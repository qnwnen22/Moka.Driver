using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Driver
{
    public partial class MongoClientAdvance
    {
        private readonly MongoClient mongoClient;
        public MongoClientAdvance(string host, string account, string password)
        {
            string connectionString = "mongodb://" + account + ":" + password + "@" + host + "/?safe=true&maxPoolSize=3000";
            this.mongoClient = new MongoClient(connectionString);
        }
        private IMongoDatabase GetDatabase(string databaseName)
        {
            return this.mongoClient.GetDatabase(databaseName);
        }
        internal IMongoCollection<T> GetCollection<T>(string dataBaseName, string collectionName = null, string separator = null)
        {
            IMongoDatabase database = this.GetDatabase(dataBaseName);
            if (string.IsNullOrWhiteSpace(collectionName))
            {
                var type = typeof(T);
                List<string> split = type.FullName.Split('+').ToList();
                split.RemoveAt(0);
                collectionName = string.Join(separator, split);
            }
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName);
            return collection;
        }
        public string CreateCollectionName(string separator, params string[] values)
        {
            return string.Join(separator, values);
        }
        
        
        

        
        
    }
}
