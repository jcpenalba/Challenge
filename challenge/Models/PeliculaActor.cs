using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class PeliculaActor
    {
        public int Id { get; set; }
        public Pelicula Pelicula { get; set; }
        public int PeliculaId { get; set; }
        public Actor Actor { get; set; }
        public int ActorId { get; set; }
    }
}
