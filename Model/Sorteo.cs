using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model
{
    [Table("Sorteo")]
    public class Sorteo
    {
        public int id { get; set; }
        [DisplayName("Sorteo número")]
        [Required(ErrorMessage = "Requerido")]
        public string numeroDeSorteo { get; set; }
        [DisplayName("Número")]
        [Required(ErrorMessage = "Requerido")]
        public string numero { get; set; }
        [DisplayName("Fecha de sorteo")]
        [Required(ErrorMessage = "Requerido")]
        public DateTime fecha { get; set; }

        [ForeignKey("loteria")]
        public int loteriaId { get; set; }
        public Loteria loteria { get; set; }
    }
}
