using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Pelicula
    {
        #region Propiedades
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public TimeSpan Duracion { get; set; }
        [Required]
        [Range(0,10)]
        public decimal Puntuacion { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal PresupuestoUsd { get; set; }
        #endregion
        public Genero Genero { get; set; }
        [Required]
        public int GeneroId { get; set; }
        public Productora Productora { get; set; }
        [Required]
        public int ProductoraId { get; set; }
        public virtual Imagen Portada { get; set; }
        public List<PeliculaActor> Actores { get; set; }
        [NotMapped]
        public List<int> ActoresId { get; set; }

    }
}
