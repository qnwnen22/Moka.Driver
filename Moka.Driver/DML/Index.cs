using MongoDB.Bson;
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
        private string CreateIndex<T>(IMongoCollection<T> mongoCollection, bool unique, Sort sort, params string[] fields)
        {
            var indexKeysDefinitionList = new List<IndexKeysDefinition<T>>() { };
            for (int i = 0; i < fields.Length; i++)
            {
                IndexKeysDefinition<T> item = null;
                switch (sort)
                {
                    case Sort.Asc:
                        item = Builders<T>.IndexKeys.Ascending(fields[i]);
                        indexKeysDefinitionList.Add(item);
                        break;
                    default:
                        item = Builders<T>.IndexKeys.Descending(fields[i]);
                        indexKeysDefinitionList.Add(item);
                        break;
                }
            }
            IndexKeysDefinition<T> combine = Builders<T>.IndexKeys.Combine(indexKeysDefinitionList);
            var createIndexOptions = new CreateIndexOptions
            {
                Unique = unique
            };
            CreateIndexModel<T> createIndexModel = new CreateIndexModel<T>(combine, createIndexOptions);
            return mongoCollection.Indexes.CreateOne(createIndexModel);
        }


        private string CreateIndex<T>(IMongoCollection<T> mongoCollection, bool unique, params string[] fields)
        {
            var indexKeysDefinitionList = new List<IndexKeysDefinition<T>>() { };
            for (int i = 0; i < fields.Length; i++)
            {
                IndexKeysDefinition<T> item = Builders<T>.IndexKeys.Ascending(fields[i]);
                indexKeysDefinitionList.Add(item);
            }
            IndexKeysDefinition<T> combine = Builders<T>.IndexKeys.Combine(indexKeysDefinitionList);
            var createIndexOptions = new CreateIndexOptions
            {
                Unique = unique
            };
            CreateIndexModel<T> createIndexModel = new CreateIndexModel<T>(combine, createIndexOptions);
            return mongoCollection.Indexes.CreateOne(createIndexModel);
        }
        public string CreateIndex<T>(string database, bool unique, params string[] fields)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database);
            return CreateIndex<T>(mongoCollection, unique, fields);
        }
        public string CreateIndex<T>(string database, string collection, bool unique, params string[] fields)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database, collection);
            return CreateIndex<T>(mongoCollection, unique, fields);
        }

        private List<string> GetIndexes<T>(IMongoCollection<T> mongoCollection)
        {
            List<BsonDocument> indexesList = mongoCollection.Indexes.List().ToList();
            var nameValues = indexesList.Select(x => x.GetValue("name").ToString()).ToList();
            return nameValues;
        }
        public List<string> GetIndexes<T>(string database)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database);
            return GetIndexes(mongoCollection);
        }
        public List<string> GetIndexes<T>(string database, string collection)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database, collection);
            return GetIndexes(mongoCollection);
        }

        private bool CheckIndexer<T>(IMongoCollection<T> mongoCollection, List<string> indexs, bool IsDrop = false)
        {
            if (indexs is null || indexs.Count <= 0) { throw new Exception("indexs is null"); }
            List<string> indexNameValueList = this.GetIndexes<T>(mongoCollection);
            foreach (var index in indexs)
            {
                bool exists = indexNameValueList.Exists(x => x == index);
                if (exists == false)
                {
                    if (IsDrop) { mongoCollection.Indexes.DropAll(); }
                    return false;
                }
            }
            return true;
        }
        public bool CheckIndexer<T>(string database, List<string> indexs)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database);
            return this.CheckIndexer<T>(mongoCollection, indexs);
        }
        public bool CheckIndexer<T>(string database, string collection, List<string> indexs)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database, collection);
            return this.CheckIndexer<T>(mongoCollection, indexs);
        }
        public void DropIndex<T>(string database, string name)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database);
            mongoCollection.Indexes.DropOne(name);
        }
        public void DropIndex<T>(string database, string collection, string name)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database, collection);
            mongoCollection.Indexes.DropOne(name);
        }
        public void DropIndexes<T>(string database)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database);
            mongoCollection.Indexes.DropAll();
        }
        public void DropIndexes<T>(string database, string collection)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database, collection);
            mongoCollection.Indexes.DropAll();
        }
    }
}
