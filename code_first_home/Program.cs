using code_first_home;
using code_first_home.entities;

internal class Program
{
    private static void Main(string[] args)
    {

            using (var context = new MusicAppContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Adding sample data
                var artist = new Artist { FirstName = "John", LastName = "Doe", Country = "USA" };
                var album = new Album { Name = "Hits", Year = 2020, Genre = "Pop", Artist = artist };
                var track1 = new Track { Name = "Song One", Duration = TimeSpan.FromMinutes(3), Album = album };
                var track2 = new Track { Name = "Song Two", Duration = TimeSpan.FromMinutes(4), Album = album };
                var playlist = new Playlist { Name = "My Playlist", Category = "Favorites", Tracks = new List<Track> { track1, track2 } };

                context.Artists.Add(artist);
                context.Albums.Add(album);
                context.Tracks.AddRange(track1, track2);
                context.Playlists.Add(playlist);
                context.SaveChanges();
            }
        
    }
}