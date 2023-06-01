using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.Design;

namespace karaokeWEBAPI.Models;

    public class KaraokeRoom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

    [BsonElement("Name")]
    public string TenQuan { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Img { get; set; } = null!;

    public int SucChua { get; set; }   

    public string NameP { get; set; } = null!;

    public int Price { get; set; }
    }

