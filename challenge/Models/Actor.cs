using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace challenge.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        [Required]
        public DateTime FechaNac { get; set; }
        [JsonIgnore]
        public List<PeliculaActor> Peliculas { get; set; }
    }
}
