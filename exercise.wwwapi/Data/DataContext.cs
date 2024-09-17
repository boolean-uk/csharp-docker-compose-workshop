using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
    
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().Navigation(x => x.Album).AutoInclude();
            modelBuilder.Entity<Album>().Navigation(x => x.Songs).AutoInclude();

            modelBuilder.Entity<Album>().HasData(new Album { Id = 1, Title = "Awe", Band="Empty Reflection" });
            modelBuilder.Entity<Song>().HasData(new Song { Id = 1, Title = "Quietly Tragic", AlbumId=1 });
            modelBuilder.Entity<Song>().HasData(new Song { Id = 2, Title = "Just a normal Day", AlbumId = 1 });
            modelBuilder.Entity<Song>().HasData(new Song { Id = 3, Title = "Live for Free", AlbumId = 1 });
            modelBuilder.Entity<Song>().HasData(new Song { Id = 4, Title = "Just a normal day", AlbumId = 1 });
            modelBuilder.Entity<Song>().HasData(new Song { Id = 5, Title = "She'd be there", AlbumId = 1 });
            modelBuilder.Entity<Song>().HasData(new Song { Id = 6, Title = "Listen", AlbumId = 1 });



        }
        
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
