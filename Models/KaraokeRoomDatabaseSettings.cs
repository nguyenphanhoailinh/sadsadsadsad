namespace karaokeWEBAPI.Models;

    public class KaraokeRoomDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string KaraokeRoomsCollectionName { get; set; } = null!;
    }

