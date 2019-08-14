using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DTO
{
    public class LoteriaDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime proximoSorteo { get; set; }
        public bool estado { get; set; }
    }
}
