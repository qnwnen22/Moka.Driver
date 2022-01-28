using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace System.Driver
{
    public partial class MongoClientAdvance
    {
        internal UpdateDefinition<T> GetUpdateDefinition<T>(List<Update> updates)
        {
            UpdateDefinitionBuilder<T> result = Builders<T>.Update;
            UpdateDefinition<T> updateDefinition = result.Set(updates[0].Field, updates[0].Value);
            for (int i = 1; i <= updates.Count - 1; i++)
            {
                updateDefinition = updateDefinition.Set(updates[i].Field, updates[i].Value);
            }
            return updateDefinition;
        }
        private long UpdateOne<T>(IMongoCollection<T> iMongoCollection, List<Filter> filters, List<Update> updates)
        {
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            UpdateDefinition<T> getUpdateDefinition = GetUpdateDefinition<T>(updates);
            UpdateResult updateOne = iMongoCollection.UpdateOne(filterDefinition, getUpdateDefinition);
            return updateOne.ModifiedCount;
        }
        private long UpdateMany<T>(IMongoCollection<T> iMongoCollection, List<Filter> filters, List<Update> updates)
        {
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            UpdateDefinition<T> getUpdateDefinition = GetUpdateDefinition<T>(updates);
            UpdateResult updateOne = iMongoCollection.UpdateMany(filterDefinition, getUpdateDefinition);
            return updateOne.ModifiedCount;
        }

        private T FindOneAndUpdate<T>(IMongoCollection<T> iMongoCollection, List<Filter> filters, List<Update> updates)
        {
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            UpdateDefinition<T> getUpdateDefinition = GetUpdateDefinition<T>(updates);
            return iMongoCollection.FindOneAndUpdate(filterDefinition, getUpdateDefinition);
        }
        public T FindOneAndUpdate<T>(string database, string collection, Filter filter, Update update)
        {
            var filterList = new List<Filter>() { filter };
            var updateList = new List<Update>() { update };
            IMongoCollection<T> getCollection = this.GetCollection<T>(database, collection);
            return FindOneAndUpdate<T>(getCollection, filterList, updateList);
        }
    }
}
