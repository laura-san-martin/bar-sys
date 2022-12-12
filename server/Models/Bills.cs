using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models;

public class Bills: IBarObject
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;

    [BsonElement("Value")]
    [JsonPropertyName("Value")]
    public string Value { get; set; } = null!;

    [BsonElement("Type")]
    [JsonPropertyName("Type")]
    public string Type { get; set; } = null!;

    [BsonElement("Date")]
    [JsonPropertyName("Date")]
    public string Date { get; set; } = null!;
}