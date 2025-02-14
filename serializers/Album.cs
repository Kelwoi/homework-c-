using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializers
{
    internal class Album
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public double Duration { get; set; }
        public string Label { get; set; }
        public List<Song> Songs { get; set; }

        public Album(string title, string artist, int year, double duration, string label, List<Song> songs)
        {
            Title = title;
            Artist = artist;
            Year = year;
            Duration = duration;
            Label = label;
            Songs = songs;
        }

        public override string ToString() => $"{Title} by {Artist} ({Year}) - {Duration} min, Label: {Label}, Songs: {Songs.Count}";
    }
}
