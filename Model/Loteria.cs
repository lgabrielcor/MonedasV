using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Loteria")]
    public class Loteria
    {
        public Loteria()
        {
        }
        public int id { get; set; }
        [DisplayName("Lotería")]
        [Required(ErrorMessage = "Requerido")]
        public string nombre { get; set; }
        [DisplayName("Dia semana")]
        [Required(ErrorMessage = "Requerido")]
        public string diaDeJuego { get; set; }
        [DataType(DataType.Time)]
        //[DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime horaDeCierre { get; set; }
        [DisplayName("Último sorteo")]
        public string ultimoSorteo { get; set; }
        [DisplayName("Estado")]
        public bool estado { get; set; }
        [DisplayName("Código de validación")]
        [Required(ErrorMessage = "Requerido")]
        public string codigoBase { get; set; }
        public DateTime proximoSorteo { get; set; }
    }
}
