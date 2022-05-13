using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace challenge.Models
{
    public class Imagen
    {
        [Key, ForeignKey("Pelicula")]
        public int Id { get; set; }
        [Required]
        public string Ruta { get; set; }
        [Required]
        public decimal Peso { get; set; }
        [Required]
        public int Ancho { get; set; }
        [Required]
        public int Alto { get; set; }
        [JsonIgnore]
        public virtual Pelicula Pelicula { get; set; }
    }
}
