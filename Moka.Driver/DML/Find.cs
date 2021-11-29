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
        internal FilterDefinition<T> GetFilterDefinition<T>(List<Filter> filters)
        {
            FilterDefinition<T> eq = null;
            foreach (var filter in filters)
            {
                if (eq is null)
                {
                    eq = Builders<T>.Filter.Eq(filter.Field, filter.Value);
                    continue;
                }
                eq = eq & Builders<T>.Filter.Eq(filter.Field, filter.Value);
            }
            return eq;
        }
        internal FilterDefinition<T> GetFilterDefinition<T>(Filter filter)
        {
            return GetFilterDefinition<T>(new List<Filter>() { filter });
        }
        internal FilterDefinition<T> GetRegexFilterDefinition<T>(Filter filter)
        {
            return Builders<T>.Filter.Regex(filter.Field, filter.Value);
        }
        internal SortDefinition<T> GetSortDefinition<T>(Sort sort, string field = "_id")
        {
            switch (sort)
            {
                case Sort.Desc:
                    return Builders<T>.Sort.Descending(field);
                default:
                    return Builders<T>.Sort.Ascending(field);
            }
        }
        public List<T> FindAll<T>(string database)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            return iMongoCollection.Find(_ => true).ToList();
        }
        public List<T> FindAll<T>(string database, Sort sort)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(_ => true).Sort(sortDefinition).ToList();
        }
        public List<T> FindMany<T>(string database, Sort sort, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(_ => true).Sort(sortDefinition).Limit(limit).ToList();
        }
        public List<T> FindMany<T>(string database, List<Filter> filters, Sort sort, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(filterDefinition).Sort(sortDefinition).Limit(limit).ToList();
        }
        public List<T> FindMany<T>(string database, Filter filter, Sort sort, int limit)
        {
            var filters = new List<Filter>() { filter };
            return FindMany<T>(database, filters, sort, limit);
        }
        public List<T> FindAll<T>(string database, string collection)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            return iMongoCollection.Find(_ => true).ToList();
        }
        public List<T> FindAll<T>(string database, string collection, Sort sort)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(_ => true).Sort(sortDefinition).ToList();
        }
        public List<T> FindMany<T>(string database, string collection, Sort sort, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(_ => true).Sort(sortDefinition).Limit(limit).ToList();
        }
        public List<T> FindMany<T>(string database, string collection, List<Filter> filters, Sort sort, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(filterDefinition).Sort(sortDefinition).Limit(limit).ToList();
        }
        public List<T> FindMany<T>(string database, string collection, Filter filter, Sort sort, int limit)
        {
            var filters = new List<Filter>() { filter };
            return FindMany<T>(database, collection, filters, sort, limit);
        }
        public T FindOne<T>(string database, List<Filter> filters)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            List<T> find = iMongoCollection.Find(filterDefinition).Limit(1).ToList();
            if (find is null || find.Count <= 0) { return default; }
            return find.First();
        }
        public T FindOne<T>(string database, Filter filter)
        {
            var filters = new List<Filter>() { filter };
            return FindOne<T>(database, filters);
        }
        public T FindOne<T>(string database, string collection, List<Filter> filters)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            List<T> find = iMongoCollection.Find(filterDefinition).Limit(1).ToList();
            if (find is null || find.Count <= 0) { return default; }
            return find.First();
        }
        public T FindOne<T>(string database, string collection, Filter filter)
        {
            var filters = new List<Filter>() { filter };
            return FindOne<T>(database, collection, filters);
        }
        public List<T> FindSkip<T>(string database, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            return iMongoCollection.Find(_ => true).Skip(skip).Limit(limit).ToList();
        }
        public List<T> FindSkip<T>(string database, List<Filter> filters, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            return iMongoCollection.Find(filterDefinition).Skip(skip).Limit(limit).ToList();
        }
        public List<T> FindSkip<T>(string database, Filter filter, int skip, int limit)
        {
            var filters = new List<Filter>() { filter };
            return FindSkip<T>(database, filters, skip, limit);
        }
        public List<T> FindSkip<T>(string database, Sort sort, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(_ => true).Sort(sortDefinition).Skip(skip).Limit(limit).ToList();
        }
        public List<T> FindSkip<T>(string database, List<Filter> filters, Sort sort, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(filterDefinition).Sort(sortDefinition).Skip(skip).Limit(limit).ToList();
        }
        public List<T> FindSkip<T>(string database, Filter filter, Sort sort, int skip, int limit)
        {
            var filters = new List<Filter>() { filter };
            return FindSkip<T>(database, filters, sort, skip, limit);
        }
        public List<T> FindSkip<T>(string database, string collection, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            return iMongoCollection.Find(_ => true).Skip(skip).Limit(limit).ToList();
        }
        public List<T> FindSkip<T>(string database, string collection, List<Filter> filters, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            return iMongoCollection.Find(filterDefinition).Skip(skip).Limit(limit).ToList();
        }
        public List<T> FindSkip<T>(string database, string collection, Filter filter, int skip, int limit)
        {
            var filters = new List<Filter>() { filter };
            return FindSkip<T>(database, collection, filters, skip, limit);
        }
        public List<T> FindSkip<T>(string database, string collection, Sort sort, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(_ => true).Sort(sortDefinition).Skip(skip).Limit(limit).ToList();
        }
        public List<T> FindSkip<T>(string database, string collection, List<Filter> filters, Sort sort, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(filterDefinition).Sort(sortDefinition).Skip(skip).Limit(limit).ToList();
        }
        public List<T> FindSkip<T>(string database, string collection, Filter filter, Sort sort, int skip, int limit)
        {
            var filters = new List<Filter>() { filter };
            return FindSkip<T>(database, collection, filters, sort, skip, limit);
        }
        public long FindCount<T>(string database)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            return iMongoCollection.Find(_ => true).Count();
        }
        public long FindCount<T>(string database, List<Filter> filters)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            return iMongoCollection.Find(filterDefinition).Count();
        }
        public long FindCount<T>(string database, Filter filter)
        {
            var filters = new List<Filter>() { filter };
            return FindCount<T>(database, filters);
        }
        public long FindCount<T>(string database, string collection)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            return iMongoCollection.Find(_ => true).Count();
        }
        public long FindCount<T>(string database, string collection, List<Filter> filters)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            FilterDefinition<T> filterDefinition = GetFilterDefinition<T>(filters);
            return iMongoCollection.Find(filterDefinition).Count();
        }
        public long FindCount<T>(string database, string collection, Filter filter)
        {
            var filters = new List<Filter>() { filter };
            return FindCount<T>(database, collection, filters);
        }
        public List<T> Regex<T>(string database, Filter filter)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            FilterDefinition<T> regexFilterDefinition = GetRegexFilterDefinition<T>(filter);
            return iMongoCollection.Find(regexFilterDefinition).ToList();
        }
        public List<T> Regex<T>(string database, Filter filter, Sort sort)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            FilterDefinition<T> regexFilterDefinition = GetRegexFilterDefinition<T>(filter);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(regexFilterDefinition).Sort(sortDefinition).ToList();
        }
        public List<T> Regex<T>(string database, Filter filter, Sort sort, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            FilterDefinition<T> regexFilterDefinition = GetRegexFilterDefinition<T>(filter);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(regexFilterDefinition).Sort(sortDefinition).Limit(limit).ToList();
        }
        public List<T> RegexSkip<T>(string database, Filter filter, Sort sort, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database);
            FilterDefinition<T> regexFilterDefinition = GetRegexFilterDefinition<T>(filter);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(regexFilterDefinition).Sort(sortDefinition).Skip(skip).Limit(limit).ToList();
        }
        public List<T> Regex<T>(string database, string collection, Filter filter)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            FilterDefinition<T> regexFilterDefinition = GetRegexFilterDefinition<T>(filter);
            return iMongoCollection.Find(regexFilterDefinition).ToList();
        }
        public List<T> Regex<T>(string database, string collection, Filter filter, Sort sort)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            FilterDefinition<T> regexFilterDefinition = GetRegexFilterDefinition<T>(filter);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(regexFilterDefinition).Sort(sortDefinition).ToList();
        }
        public List<T> Regex<T>(string database, string collection, Filter filter, Sort sort, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            FilterDefinition<T> regexFilterDefinition = GetRegexFilterDefinition<T>(filter);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(regexFilterDefinition).Sort(sortDefinition).Limit(limit).ToList();
        }
        public List<T> RegexSkip<T>(string database, string collection, Filter filter, Sort sort, int skip, int limit)
        {
            IMongoCollection<T> iMongoCollection = this.GetCollection<T>(database, collection);
            FilterDefinition<T> regexFilterDefinition = GetRegexFilterDefinition<T>(filter);
            SortDefinition<T> sortDefinition = GetSortDefinition<T>(sort);
            return iMongoCollection.Find(regexFilterDefinition).Sort(sortDefinition).Skip(skip).Limit(limit).ToList();
        }
    }
}
