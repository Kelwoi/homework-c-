﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_first_home.entities
{
    public class Album
    {

            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public int Year { get; set; }
            public string Genre { get; set; } = string.Empty;
            public int ArtistId { get; set; }
            public Artist Artist { get; set; } = null!;
            public List<Track> Tracks { get; set; } = new();
        
    }
}
