using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_first_home.entities
{
    public class Track
    {

            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public TimeSpan Duration { get; set; }
            public int AlbumId { get; set; }
            public Album Album { get; set; } = null!;
            public List<Playlist> Playlists { get; set; } = new();
        
    }
}
