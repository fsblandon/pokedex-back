using System;
using Microsoft.EntityFrameworkCore;
using pokeapi.Models;

namespace pokeapi.DataContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Trainer> Trainers { get; set; }
    }
}
