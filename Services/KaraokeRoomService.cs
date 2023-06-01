using karaokeWEBAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace karaokeWEBAPI.Services
{
    public class KaraokeRoomService
    {
        private readonly IMongoCollection<KaraokeRoom> roomcollection;

        public KaraokeRoomService(IOptions<KaraokeRoomDatabaseSettings> karaokeroomDatabaseSettings)
        {
            var mongoClient = new MongoClient(karaokeroomDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(karaokeroomDatabaseSettings.Value.DatabaseName);
            roomcollection = mongoDatabase.GetCollection<KaraokeRoom>(karaokeroomDatabaseSettings.Value.KaraokeRoomsCollectionName);

        }
        public async Task<List<KaraokeRoom>> GetAsync() =>
            await roomcollection.Find(_ => true).ToListAsync();

        public async Task<KaraokeRoom?> GetAsync(string id)=>
            await roomcollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(KaraokeRoom  newkaraokeRoom) =>
        await roomcollection.InsertOneAsync(newkaraokeRoom);

        public async Task UpdateAsync(string id, KaraokeRoom updatedkaraokeRoom) =>
            await roomcollection.ReplaceOneAsync(x => x.Id == id, updatedkaraokeRoom);

        public async Task RemoveAsync(string id) =>
            await roomcollection.DeleteOneAsync(x => x.Id == id);
    }
}
