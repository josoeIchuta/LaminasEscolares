using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaminasEscolares.Models
{
    public class LaminasDto
    {
        public int Id { get; set; }
        public int Categoria { get; set; }
        public int Reglon { get; set; }
        public string Lamina { get; set; }
        //public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
