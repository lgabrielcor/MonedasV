using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Vendedor")]
    public class Vendedor
    {
        public int id { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Requerido")]
        public string nombre { get; set; }
        [DisplayName("Usuario")]
        [Required(ErrorMessage = "Requerido")]
        public string usuario { get; set; }
        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "Requerido")]
        public string telefono { get; set; }
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Requerido")]
        public string password { get; set; }
        public bool estado { get; set; }
    }
}
