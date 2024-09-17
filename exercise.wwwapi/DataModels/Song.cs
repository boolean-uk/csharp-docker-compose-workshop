using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("song")]
    public class Song
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
      
        [Column("albumid_fk")]
        [ForeignKey("Album")]
        public int AlbumId {  get; set; }
        [JsonIgnore]
        public Album Album { get; set;}

    }
}
