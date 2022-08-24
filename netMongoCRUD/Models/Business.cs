using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netMongoCRUD.Models
{
    public class Business
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Service { get; set; }
    }
}
