using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restfulApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movie");
        }
    }
}