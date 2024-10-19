using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace recordX.Models
{
    public class Transaction
    {
        [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            [BsonElement("TransactionID")]
            public string TransactionID { get; set; }

            [BsonElement("DateTime")]
            public DateTime DateTime { get; set; }

            [BsonElement("CustomerNIC")]
            public string CustomerNIC { get; set; }

            [BsonElement("Amount")]
            public double Amount { get; set; }

            [BsonElement("Paid")]
            public bool Paid { get; set; }
    }
}