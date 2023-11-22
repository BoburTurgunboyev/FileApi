using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FileApi.Entities
{
    public class User
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string UserName { get; set; } = default!;
        [JsonIgnore]
        public string? ImageUrl { get; set; }

        [NotMapped]
      
        public IFormFile? Image { get; set; }

    }
}
