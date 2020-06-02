using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEnviame.Models
{
    public class Distancia
    {
        public string Direccion { get; set; }
        public decimal DistanciaDireccion { get; set; }
        public int DiasEntrega { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
