﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjMongoDbApi.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string CEP { get; set; }
    }
}
