using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Repositories.Interfaces
{
    public interface IPeliculaRepository
    {
        IList<Pelicula> GetAll();
        Pelicula Create(Pelicula newPelicula);
        void Update(Pelicula pelicula);
        void Delete(int id);
        Pelicula GetById(int id);
    }
}
