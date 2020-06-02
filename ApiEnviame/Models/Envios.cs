using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEnviame.Models
{
    public class Envios
    {
        public long Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string LugarEnvío { get; set; }
        [Required]
        public decimal Latitud { get; set; }
        [Required]
        public decimal Longitud { get; set; }
        [Required]
        public DateTime FechaEnvio { get; set; }
        [Required]
        public DateTime FechaEstimadaEntrega { get; set; }
        [Required]
        public string NombrePersonaEnvio { get; set; }
        [Required]
        public string NombrePersonaRecibe { get; set; }
        [Required]
        public string EntidadEnvio { get; set; }
    }
}
