using System;
using System.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ConsoleApp.Collections;

namespace ConsoleApp
{
    class Program
    {
        public class P
        {

        }

        public class Member : P
        {
            public string _id { get; set; }
            public string Account { get; set; }
            public string Password { get; set; }

            public class Test
            {
                public string aa { get; set; }
            }
            //[JsonProperty("")]
            public Test _Test { get; set; }
            public Member(string account, string password)
            {
                _id = Bson.GenerateNewId();
                Account = account;
                Password = password;
            }


        }

        static void Main(string[] args)
        {
            var mongoClientAdvance = new MongoClientAdvance("localhost", "howsoft", "zero00!#");
            string database = "qnwnen22";
            var collectionName = mongoClientAdvance.CreateCollectionName("_", database, "Coupang", "Korea");

            //List<Product> productList = new List<Product>();
            //for (int i = 1; i <= 10000; i++)
            //{
            //    Product product = new Product();
            //    product.Code = i.ToString();
            //    product.Title = i.ToString();
            //    product.Site = new Site("Coupang", "Korea");
            //    productList.Add(product);
            //}

            //mongoClientAdvance.CreateIndex<Product>(database, collectionName, true, nameof(Product.Code));
            //mongoClientAdvance.CreateIndex<Product>(database, collectionName, true, nameof(Product.Title));
            //mongoClientAdvance.CreateIndex<Product>(database, collectionName, false, nameof(Product.Status));
            //mongoClientAdvance.CreateIndex<Product>(database, collectionName, false, nameof(Product.Site.Name));
            //mongoClientAdvance.CreateIndex<Product>(database, collectionName, false, nameof(Product.Site.Contry));
            //var insertMany = mongoClientAdvance.InsertMany(database, collectionName, productList);


            var filter = new Filter("Code", "100");
            var regexSkip = mongoClientAdvance.RegexSkip<Product>(database, collectionName, filter, Sort.Desc, 0, 500);

            ;
            var findAll = mongoClientAdvance.FindAll<Product>(database, collectionName);






        }


    }
}
