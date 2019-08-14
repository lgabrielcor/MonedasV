using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Apuesta")]
    public class Apuesta
    {
        public int id { get; set; }
        [DisplayName("Número")]
        [Required(ErrorMessage = "Requerido")]
        public string numero { get; set; }
        [DisplayName("Directo")]

        public int directo { get; set; }
        [DisplayName("Combinado")]

        public int? combinado { get; set; }
        [DisplayName("Pata")]
        public int? pata { get; set; }
        [DisplayName("Uña")]
        public int? una { get; set; }

    }
}
