using MongoDB.Bson.Serialization.Attributes;

namespace ProjectApiBasics.Data
{
    public class Game
    {
        [BsonId] // To set primary key
        [BsonRepresentation(MongoDB.Bson.BsonType.String)] // On how mongodb will treat this data type to save in the database
        public Guid Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required string Studio { get; set; } = string.Empty;

        public required float Review { get; set; }

        public required DateTimeOffset DateTimeCreated { get; set; }
    }
}
