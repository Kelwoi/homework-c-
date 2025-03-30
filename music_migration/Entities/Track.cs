using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace music_migration.Entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; } = null!;
        public List<Playlist> Playlists { get; set; } = new();
        public double Rating { get; set; }
        public int PlayCount { get; set; }
        public string? Lyrics { get; set; } 
    }
}
