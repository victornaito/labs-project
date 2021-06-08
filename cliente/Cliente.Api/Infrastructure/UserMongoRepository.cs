using System.Threading.Tasks;
using cliente.Cliente.Api.Domain;
using cliente.Cliente.Api.Domain.Abstractions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cliente.Cliente.Api.Infrastructure
{
    public class UserMongoRepository : IUserRepository
    {
        private IMongoCollection<User> _userCollection;

        public UserMongoRepository()
        {
            IMongoClient mongoClient = new MongoClient();
            _userCollection = mongoClient.GetDatabase("Lab").GetCollection<User>("User");
        }

        public async Task SaveAsync(User user)
        {
            var filter = new BsonDocument("Name", user.Name);
            var update = Builders<User>.Update.Set("Name", user.Name);
            await _userCollection.FindOneAndUpdateAsync<User>(filter, update);
        }
    }
}