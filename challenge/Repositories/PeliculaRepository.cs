using challenge.Models;
using challenge.Repositories.Interfaces;
using hallenge.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly AplicationDBContext _context;

        public PeliculaRepository(AplicationDBContext context)
        {
            _context = context;
        }

        public IList<Pelicula> GetAll()
        {
            return _context.pelicula
                         .Include(x => x.Actores)
                         .ThenInclude(x => x.Actor)
                         .Include(x => x.Portada)
                         .Include(x => x.Genero)
                         .Include(x => x.Productora)
                         .ToList();
           
        }

        public Pelicula GetById(int id)
        {
            return _context.pelicula
                        .Include(x => x.Actores)
                        .ThenInclude(x => x.Actor)
                        .Include(x => x.Portada)
                        .Include(x => x.Genero)
                        .Include(x => x.Productora)
                        .FirstOrDefault(x=>x.Id==id);
            
        }

        public Pelicula Create(Pelicula newPelicula)
        {
            try
            {
                _context.pelicula.Add(newPelicula);
                _context.SaveChanges();

                if (newPelicula.ActoresId.Count != 0)
                {

                    foreach (var actor in newPelicula.ActoresId)
                    {
                        PeliculaActor peliculaActor = new PeliculaActor();
                        peliculaActor.ActorId = actor;
                        peliculaActor.PeliculaId = newPelicula.Id;
                        _context.pelicula_actor.Add(peliculaActor);
                        _context.SaveChanges();
                    }
                }


                return newPelicula;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Error Base De Datos");
            }
        }

       

        public void Update(Pelicula pelicula)
        {
            Pelicula peliculaDB =  _context.pelicula.FirstOrDefault(x=>x.Id == pelicula.Id);
            if (peliculaDB == null)
            {
                throw new NotImplementedException("Error");
            }
            map(peliculaDB, pelicula);
            try
            {
                _context.pelicula.Update(peliculaDB);
                List<PeliculaActor> PeliculaActor = _context.pelicula_actor.Where(x => x.PeliculaId == pelicula.Id).ToList();
                foreach (var peliculaActor in PeliculaActor)
                {
                    _context.pelicula_actor.Remove(peliculaActor);
                }
                if (pelicula.ActoresId.Count != 0)
                {
                    foreach (var actor in pelicula.ActoresId)
                    {
                        PeliculaActor peliculaActor = new PeliculaActor();
                        peliculaActor.ActorId = actor;
                        peliculaActor.PeliculaId = pelicula.Id;
                        _context.pelicula_actor.Add(peliculaActor);
                    }
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Error Base De Datos");
            }
        }

        private void map(Pelicula peliculaDB, Pelicula pelicula)
        {
            peliculaDB.Duracion = pelicula.Duracion;
            peliculaDB.GeneroId = pelicula.GeneroId;
            peliculaDB.Nombre = pelicula.Nombre;
            peliculaDB.PresupuestoUsd = pelicula.PresupuestoUsd;
            peliculaDB.ProductoraId = pelicula.ProductoraId;
            peliculaDB.Puntuacion = pelicula.Puntuacion;

        }

        public void Delete(int id)
        {
            Pelicula peliculaDB = _context.pelicula.FirstOrDefault(x => x.Id == id);
            if (peliculaDB == null)
            {
                throw new NotImplementedException("Error");
            }

            try
            {
                _context.pelicula.Remove(peliculaDB);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Error Base De Datos");
            }
        }

     

    }
}
