
using music_migration.Entities;
using music_migration;
internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new MusicAppContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


            var artist = new Artist { FirstName = "John", LastName = "Doe", Country = "USA" };
            var album = new Album { Name = "Hits", Year = 2020, Genre = "Pop", Artist = artist, Rating = 4.5 };
            var track1 = new Track { Name = "Song One", Duration = TimeSpan.FromMinutes(3), Album = album, Rating = 4.7, PlayCount = 100, Lyrics = "La la la..." };
            var track2 = new Track { Name = "Song Two", Duration = TimeSpan.FromMinutes(4), Album = album, Rating = 4.3, PlayCount = 50, Lyrics = "Oh oh oh..." };
            var playlist = new Playlist { Name = "My Playlist", Category = "Favorites", Tracks = new List<Track> { track1, track2 } };

            context.Artists.Add(artist);
            context.Albums.Add(album);
            context.Tracks.AddRange(track1, track2);
            context.Playlists.Add(playlist);
            context.SaveChanges();
        }
    }
    public static void DisplayPopularTracks(MusicAppContext context, int albumId)
    {
        var averagePlays = context.Tracks.Where(t => t.AlbumId == albumId).Average(t => t.PlayCount);
        var popularTracks = context.Tracks.Where(t => t.AlbumId == albumId && t.PlayCount > averagePlays).ToList();
        foreach (var track in popularTracks)
        {
            Console.WriteLine($"{track.Name} - {track.PlayCount} plays");
        }
    }

    public static void DisplayTopTracksAndAlbums(MusicAppContext context, int artistId)
    {
        var topTracks = context.Tracks.Where(t => t.Album.ArtistId == artistId)
                                      .OrderByDescending(t => t.Rating)
                                      .Take(3)
                                      .ToList();

        var topAlbums = context.Albums.Where(a => a.ArtistId == artistId)
                                       .OrderByDescending(a => a.Rating)
                                       .Take(3)
                                       .ToList();

        Console.WriteLine("Top 3 Tracks:");
        foreach (var track in topTracks)
        {
            Console.WriteLine($"{track.Name} - Rating: {track.Rating}");
        }

        Console.WriteLine("Top 3 Albums:");
        foreach (var album in topAlbums)
        {
            Console.WriteLine($"{album.Name} - Rating: {album.Rating}");
        }
    }

    public static void SearchTrack(MusicAppContext context, string query)
    {
        var results = context.Tracks.Where(t => t.Name.Contains(query) || (t.Lyrics != null && t.Lyrics.Contains(query))).ToList();
        foreach (var track in results)
        {
            Console.WriteLine($"Found: {track.Name}");
        }
    }
}