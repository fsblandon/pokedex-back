using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pokeapi.Models;

namespace pokeapi.DataContext.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var _context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (_context.Trainers.Any())
                {
                    return;
                }

                /*_context.Trainers.Add(
                    new Trainer { Name = "Pedro", Email = "pedro@gmail.com" }
                );*/

                _context.SaveChanges();

            }

        }
    }
}
