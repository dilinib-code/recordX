using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using recordX.Components;
using recordX.Models;

namespace recordX.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration config)
        {
            try
            {
                var client = new MongoClient(config["MongoDB:ConnectionString"]);
                _database = client.GetDatabase(config["MongoDB:DatabaseName"]);
                // Log all collections in the database
                var collections = _database.ListCollections().ToList();
                Console.WriteLine("Collections in the database:");
                foreach (var collection in collections)
                {
                    Console.WriteLine(collection["name"].AsString);
                }
                Console.WriteLine("Connected to MongoDB successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to MongoDB: {ex.Message}");
                throw;
            }
        }

       public IMongoCollection<Customer> Customers
        {
            get
            {
                Console.WriteLine("Accessing 'accounts' collection from MongoDB.");
                try
                {
                    var count = _database.GetCollection<Customer>("Accounts").CountDocuments(FilterDefinition<Customer>.Empty);
                    Console.WriteLine($"Number of documents in 'accounts' collection: {count}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accessing 'Accounts' collection: {ex.Message}");
                }
                return _database.GetCollection<Customer>("Accounts");
            }
        }
        
        public IMongoCollection<Transaction> Transactions
        {
            get
            {
                Console.WriteLine("Accessing 'transactions' collection from MongoDB.");
                try
                {
                    var count = _database.GetCollection<Transaction>("transactions").CountDocuments(FilterDefinition<Transaction>.Empty);
                    Console.WriteLine($"Number of documents in 'transactions' collection: {count}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error accessing 'transactions' collection: {ex.Message}");
                }
                return _database.GetCollection<Transaction>("Transactions");
            }
        }
    }
}