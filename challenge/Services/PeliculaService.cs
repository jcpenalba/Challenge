using challenge.Models;
using challenge.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _peliculaRepository;

        public PeliculaService(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        IList<Pelicula> IPeliculaService.GetAll()
        {
            return _peliculaRepository.GetAll();
        }

        public Pelicula GetById(int id)
        {
            return _peliculaRepository.GetById(id);
        }

        public Pelicula Create(Pelicula newPelicula)
        {
            return _peliculaRepository.Create(newPelicula);
        }

        public void Update(Pelicula pelicula)
        {
            _peliculaRepository.Update(pelicula);
        }

        public void Delete(int id)
        {
            _peliculaRepository.Delete(id);
        }

        
    }
}
