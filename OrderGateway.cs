using MongoDB.Driver;
using MongoDB.Bson;

namespace Acme.Gateway
{
    // Reads the shared `orders` collection and maintains its own `shipments`.
    public class OrderGateway
    {
        private readonly IMongoDatabase _db;
        public OrderGateway(IMongoDatabase db) { _db = db; }

        public long PendingOrders()
        {
            var orders = _db.GetCollection<BsonDocument>("orders");
            return orders.CountDocuments(Builders<BsonDocument>.Filter.Empty);
        }

        public void Ship(BsonDocument order)
        {
            _db.GetCollection<BsonDocument>("orders").UpdateOne(
                Builders<BsonDocument>.Filter.Eq("_id", order["_id"]),
                Builders<BsonDocument>.Update.Set("status", "shipped"));
            _db.GetCollection<BsonDocument>("shipments").InsertOne(order);
        }
    }
}
