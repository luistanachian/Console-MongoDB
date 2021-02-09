using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Console_MongoDB
{
    public class EmployeeModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("lstaname")]
        public string LastName { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("status")]
        public string Status { get; set; }

    }
}
