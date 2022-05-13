using challenge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.DTOs.Peliculas
{
    public class PeliculaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public TimeDTO Duracion { get; set; }
        [Required]
        [Range(0, 10)]
        public decimal Puntuacion { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal PresupuestoUsd { get; set; }
        [Required]
        public int GeneroId { get; set; }
        [Required]
        public int ProductoraId { get; set; }
        [Required]
        public Imagen Portada { get; set; }
        public List<int> ActoresId { get; set; }
    }
}
