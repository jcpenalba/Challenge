using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.DTOs.Peliculas
{
    public class TimeDTO
    {
        [Required]
        [Range(0, 24,ErrorMessage = "Horas no Validas")]
        public int Hours { get; set; }
        
        [Required]
        [Range(0, 59, ErrorMessage = "Minutos no validos")]
        public int Minutes { get; set; }

        [Required]  
        [Range(0, 59, ErrorMessage = "Segundos no validos")]
        public int Seconds { get; set; }
    }
}
