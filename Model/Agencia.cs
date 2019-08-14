﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Agencia")]
    public class Agencia
    {
        public int id { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Requerido")]
        public string nombre { get; set; }
        [DisplayName("N.I.T")]
        [Required(ErrorMessage = "Requerido")]
        public string nit { get; set; }
        [DisplayName("Nombre representante legal")]
        [Required(ErrorMessage = "Requerido")]
        public string nombreRepresentanteLegal { get; set; }
        [DisplayName("Cédula representante legal")]
        [Required(ErrorMessage = "Requerido")]
        public string cedulaRepresentanteLegal { get; set; }
        [DisplayName("Dirección")]
        [Required(ErrorMessage = "Requerido")]
        public string direccion { get; set; }
        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "Requerido")]
        public string telefono { get; set; }

        public List<Administrador> administradores { get; set; }
        public List<Vendedor> vendedores { get; set; }
        public bool estado { get; set; }

    }
}
