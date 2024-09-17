using exercise.wwwapi.DataModels;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    /// <summary>
    /// Extension endpoint
    /// </summary>
    public static class AlbumEndpoint
    {
        public static void AlbumEndpointConfiguration(this WebApplication app)
        {
            var albums = app.MapGroup("albums");
            albums.MapGet("/", GetAlbums);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAlbums(IRepository<Album> repository)
        {
            var results = await repository.Get();
            var AlbumDTOs = new List<Object>();
            foreach (var album in results)
            {
                var SongDTOs = new List<Object>();
                foreach(var song in album.Songs)
                {
                    SongDTOs.Add(new { Title = song.Title });

                }
                AlbumDTOs.Add(new { Title=album.Title, Songs=SongDTOs});

            }
            return TypedResults.Ok(AlbumDTOs);
        }

        
       
    }
}
