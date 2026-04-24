using MongoDB.Driver;
using APIhibridaASP.Models;

namespace APIhibridaASP.Data
{
    public class MongoDbContext
    {
         private readonly IMongoDatabase _database;

            public MongoDbContext(IConfiguration configuration)
            {
                var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
                _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
            }

            public IMongoCollection<Proyecto> Proyectos =>
                _database.GetCollection<Proyecto>("Proyectos");
    }
}
