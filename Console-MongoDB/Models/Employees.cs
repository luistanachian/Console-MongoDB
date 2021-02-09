using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Console_MongoDB.Models
{
    public class Employees
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }

    }
}
