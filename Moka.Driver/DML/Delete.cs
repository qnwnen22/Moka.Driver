using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Driver
{
    public partial class MongoClientAdvance
    {
        private long DeleteOne<T>(IMongoCollection<T> iMongoCollection, List<Filter> filters)
        {
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            DeleteResult deleteResult = iMongoCollection.DeleteOne(filterDefinition);
            return deleteResult.DeletedCount;
        }
        private long DeleteMany<T>(IMongoCollection<T> iMongoCollection, List<Filter> filters)
        {
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            DeleteResult deleteResult = iMongoCollection.DeleteMany(filterDefinition);
            return deleteResult.DeletedCount;
        }

        private T FindOneAndDelete<T>(IMongoCollection<T> iMongoCollection, List<Filter> filters)
        {
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            return iMongoCollection.FindOneAndDelete(filterDefinition);
        }

        public long DeleteOne<T>(string database, Filter filter)
        {
            var filters = new List<Filter>() { filter };
            IMongoCollection<T> iMongoCollection = GetCollection<T>(database);
            return DeleteOne<T>(iMongoCollection, filters);
        }
        public long DeleteOne<T>(string database, string collection, Filter filter)
        {
            var filters = new List<Filter>() { filter };
            IMongoCollection<T> iMongoCollection = GetCollection<T>(database, collection);
            return DeleteOne<T>(iMongoCollection, filters);
        }

        public long DeleteOne<T>(string database, List<Filter> filters)
        {
            IMongoCollection<T> iMongoCollection = GetCollection<T>(database);
            return DeleteOne<T>(iMongoCollection, filters);
        }
        public long DeleteOne<T>(string database, string collection, List<Filter> filters)
        {
            IMongoCollection<T> iMongoCollection = GetCollection<T>(database, collection);
            return DeleteOne<T>(iMongoCollection, filters);
        }


        public long DeleteMany<T>(string database, Filter filter)
        {
            var filters = new List<Filter>() { filter };
            IMongoCollection<T> iMongoCollection = GetCollection<T>(database);
            return DeleteMany<T>(iMongoCollection, filters);
        }
        public long DeleteMany<T>(string database, string collection, Filter filter)
        {
            var filters = new List<Filter>() { filter };
            IMongoCollection<T> iMongoCollection = GetCollection<T>(database, collection);
            return DeleteMany<T>(iMongoCollection, filters);
        }

        public long DeleteMany<T>(string database, List<Filter> filters)
        {
            IMongoCollection<T> iMongoCollection = GetCollection<T>(database);
            return DeleteMany<T>(iMongoCollection, filters);
        }
        public long DeleteMany<T>(string database, string collection, List<Filter> filters)
        {
            IMongoCollection<T> iMongoCollection = GetCollection<T>(database, collection);
            return DeleteOne<T>(iMongoCollection, filters);
        }

        public T FindOneAndDelete<T>(string database, string collection, List<Filter> filters)
        {
            IMongoCollection<T> iMongoCollection = GetCollection<T>(database, collection);
            return FindOneAndDelete(iMongoCollection, filters);
        }
    }
}
