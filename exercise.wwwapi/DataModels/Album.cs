using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("album")]
    public class Album
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("artist")]
        public string Band { get; set; }
        [JsonIgnore]
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
