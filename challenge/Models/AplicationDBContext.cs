using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class AplicationDBContext : DbContext
    {
        public DbSet<Pelicula> pelicula { get; set; }
        public DbSet<Actor> actor { get; set; }
        public DbSet<Productora> productora { get; set; }
        public DbSet<Imagen> imagen { get; set; }
        public DbSet<Genero> genero { get; set; }
        public DbSet<PeliculaActor> pelicula_actor { get; set; }


        public AplicationDBContext(DbContextOptions<AplicationDBContext> options): base(options)
        {

        }
    }

    
}
