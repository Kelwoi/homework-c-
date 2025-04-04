﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Generic_Book
{
    public class Book
    {

        
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public int Year { get; set; }

            public Book(string title, string author, string genre, int year)
            {
                Title = title;
                Author = author;
                Genre = genre;
                Year = year;
            }

            public override string ToString()
            {
                return $"{Title} - {Author} ({Genre}, {Year})";
            }


    }
}
