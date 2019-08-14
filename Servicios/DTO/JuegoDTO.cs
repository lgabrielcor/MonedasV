using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DTO
{
    public class JuegoDTO
    {
        public string telefono { get; set; }
        public string loteria { get; set; }
        public string cifras { get; set; }
        public List<ApuestaDTO> apuestas { get; set; }
        public string serial { get; set; }
        public string codigoDeValidacion { get; set; }
        public int vendedorId { get; set; }
    }
}
