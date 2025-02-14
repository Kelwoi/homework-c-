using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializers
{
    internal class Song
    {
        public string Title { get; set; }
        public double Duration { get; set; }
        public string Genre { get; set; }

        public Song(string title, double duration, string genre)
        {
            Title = title;
            Duration = duration;
            Genre = genre;
        }
    }
}
