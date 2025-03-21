
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code_first_home.entities;
namespace code_first_home
{
    public class MusicAppContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;
                                        Initial Catalog = Music;
                                        Integrated Security = True;
                                        Connect Timeout = 2;
                                        Encrypt = False;
                                        Trust Server Certificate = False;
                                        Application Intent = ReadWrite;
                                        Multi Subnet Failover = False");
        }

    }
}
