using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace recordX.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("NIC")]
        public string NIC { get; set; }

        [BsonElement("DOB")]
        public DateTime DOB { get; set; }

        [BsonElement("Job")]
        public string Job { get; set; }

        [BsonElement("Location")]
        public string Location { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}