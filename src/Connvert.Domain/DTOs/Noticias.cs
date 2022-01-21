using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Connvert.Domain.DTOs
{
    public class Noticias
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        [BsonElement("Titulo")]
        public string Titulo { get; private set; }
        public string Texto { get; private set; }
        public string Autor { get; private set; }


    }
}
