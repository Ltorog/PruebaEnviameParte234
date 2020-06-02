using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ApiEnviame.Models
{
    public class DetalleEnvios
    {
        public long Id { get; set; }
        [Required]
        public string EstadoEnvio{ get; set; }
        [Required]
        public DateTime FechaActualizacion { get; set; }
        public string ObservacionDetalle { get; set; }
        [Required]
        public Envios Envio { get; set; }
    }
}
