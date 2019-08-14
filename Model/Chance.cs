using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Chance")]
    public class Chance
    {
        public Chance()
        {
            apuestas = new List<Apuesta>();
        }
        public int id { get; set; }

        [ForeignKey("loteria")]
        public int loteriaId { get; set; }
        public Loteria loteria { get; set; }
        [DisplayName("Fecha")]
        [Required(ErrorMessage = "Requerido")]
        public DateTime fecha { get; set; }
        [DisplayName("Sorteo")]
        [Required(ErrorMessage = "Requerido")]
        public string sorteo { get; set; }
        [DisplayName("Total apuesta")]
        [Required(ErrorMessage = "Requerido")]
        public int totalApuesta { get; set; }
        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "Requerido")]
        public string telefono { get; set; }
        [DisplayName("Serial")]
        [Required(ErrorMessage = "Requerido")]
        public string serial { get; set; }
        [DisplayName("Validación")]
        [Required(ErrorMessage = "Requerido")]
        public string codigoDeValidacion { get; set; }
        [DisplayName("Cifras")]
        [Required(ErrorMessage = "Requerido")]
        public int cifras { get; set; }
        public List<Apuesta> apuestas { get; set; }

        [ForeignKey("vendedor")]
        public int vendedorId { get; set; }
        public Vendedor vendedor { get; set; }

    }
}
