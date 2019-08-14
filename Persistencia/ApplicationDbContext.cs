using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Crea la conexion a la base de datos.
        /// </summary>
        /// <returns></returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Model.Loteria> loterias { get; set; }
        public System.Data.Entity.DbSet<Model.Sorteo> sorteo { get; set; }
        public System.Data.Entity.DbSet<Model.Vendedor> vendedores { get; set; }
        public System.Data.Entity.DbSet<Model.Administrador> administrador { get; set; }
        public System.Data.Entity.DbSet<Model.Chance> chances { get; set; }
        public System.Data.Entity.DbSet<Model.Apuesta> apuestas { get; set; }

        public System.Data.Entity.DbSet<Model.Agencia> Agencias { get; set; }
    }
}
