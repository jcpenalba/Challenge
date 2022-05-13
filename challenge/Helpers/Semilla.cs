using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Helpers
{
    public static class Semilla
    {
        public static void GenerarDatos(AplicationDBContext context)
        {
            context.Database.EnsureCreated();
            if (context.pelicula.Any())
            {
                return;
            }
            var generos = new Genero[]
            {
                new Genero() { Nombre="Terror"},
                new Genero() { Nombre="Drama"},
                new Genero() { Nombre="Infantil"},
                new Genero() { Nombre="Suspenso"},
                new Genero() { Nombre = "Comedia" }
            };

            var actores = new Actor[]
            {
                new Actor() { Nombre="Robetr", Apellido= "De Niro",FechaNac=new DateTime(1943-08-17)},
                new Actor() { Nombre="Johnny", Apellido= "Depp",FechaNac=new DateTime(1963-06-09)},
                new Actor() { Nombre="Keanu", Apellido= "Reeves",FechaNac=new DateTime(1964-09-02)},
                new Actor() { Nombre="Denzel", Apellido= "Washington",FechaNac=new DateTime(1954-12-28)}
            };

            var productoras = new Productora[]
            {
                new Productora() { Nombre="Warner Bros.", FechaFundacion=new DateTime(1923-04-04)},
                new Productora() { Nombre="20th Century Fox", FechaFundacion=new DateTime(1935-05-31)},
                new Productora() { Nombre="Pixar", FechaFundacion=new DateTime(1964-02-03)}
            };
            context.genero.AddRange(generos);
            context.actor.AddRange(actores);
            context.productora.AddRange(productoras);
            context.SaveChanges();
        }
            
        }
    }

