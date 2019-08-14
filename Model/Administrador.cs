using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Administrador")]
    public class Administrador
    {
        public int id { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Requerido")]
        public string nombre { get; set; }
        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "Requerido")]
        public string telefono { get; set; }
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Requerido")]
        public string password { get; set; }
        public bool estado { get; set; }

        public string perfil { get; set; }

    }
}
