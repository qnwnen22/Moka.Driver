using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Driver.DML
{
    public partial class MongoClientAdvance
    {
        public static string GetID()
        {
            return ObjectId.GenerateNewId().ToString();
        }
    }
}
