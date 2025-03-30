using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using music_migration.Entities;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace music_migration
{
    internal class MusicAppContext : DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Artist> Artists { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Album> Albums { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Track> Tracks { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Playlist> Playlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MusicAppDB;Trusted_Connection=True;");
        }
    }
}
