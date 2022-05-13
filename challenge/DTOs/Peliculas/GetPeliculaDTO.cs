using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.DTOs.Peliculas
{
    public class GetPeliculaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TimeDTO Duracion { get; set; }
        public decimal Puntuacion { get; set; }
        public decimal PresupuestoUsd { get; set; }
        public string Genero  { get; set; }
        public string Productora { get; set; }
        public Imagen Portada { get; set; }
        public List<Actor> Actores { get; set; }
    }
}
