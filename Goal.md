using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Goal
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public decimal TargetAmount { get; set; }

    public decimal CurrentAmount { get; set; }

    // Optional icon field
    [BsonElement("icon")]
    [BsonIgnoreIfNull]
    public string? Icon { get; set; }
}
