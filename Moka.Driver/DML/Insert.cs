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
        private bool InsertOne<T>(IMongoCollection<T> mongoCollection, T t)
        {
            try { mongoCollection.InsertOne(t); }
            catch (MongoException) { return false; }
            catch (Exception) { return false; }
            return true;
        }
        public bool InsertOne<T>(string database, T t)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database);
            return InsertOne<T>(mongoCollection, t);
        }
        public bool InsertOne<T>(string database, string collection, T t)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database, collection);
            return InsertOne<T>(mongoCollection, t);
        }
        private int InsertMany<T>(IMongoCollection<T> mongoCollection, List<T> tList)
        {
            try
            {
                var insertManyOptions = new InsertManyOptions() { IsOrdered = false };
                mongoCollection.InsertMany(tList, insertManyOptions);
            }
            catch (MongoBulkWriteException mongoBulkWriteException)
            {
                return tList.Count - mongoBulkWriteException.WriteErrors.Count;
            }
            catch (Exception) { return -1; }
            return tList.Count;
        }

        public int InsertMany<T>(string database, List<T> tList)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database);
            return InsertMany<T>(mongoCollection, tList);
        }
        public int InsertMany<T>(string database, string collection, List<T> tList)
        {
            IMongoCollection<T> mongoCollection = GetCollection<T>(database, collection);
            return InsertMany<T>(mongoCollection, tList);
        }
    }
}
