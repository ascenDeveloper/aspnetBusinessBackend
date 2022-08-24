using MongoDB.Bson;
using MongoDB.Driver;
using netMongoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netMongoCRUD.Repositories
{
    public class BusinessCollection : IBusinessCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Business> Collection;

        public BusinessCollection()
        {
            Collection = _repository.db.GetCollection<Business>("Businesses");
        }
        public async Task DeleteBusiness(string id)
        {
            var filter = Builders<Business>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Business>> GetAllBusinesses()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Business> GetProductById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertBusiness(Business business)
        {
            await Collection.InsertOneAsync(business);
        }

        public async Task UpdateBusiness(Business business)
        {
            var filter = Builders<Business>.Filter.Eq(s => s.Id, business.Id);
            await Collection.ReplaceOneAsync(filter, business);
        }
    }
}
