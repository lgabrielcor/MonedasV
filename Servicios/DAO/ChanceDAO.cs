using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Model;
using Persistencia;
using Servicios.DTO;
using System.Data.Entity;

namespace Servicios.DAO
{
    public class ChanceDAO
    {
        Controller controller;
        ApplicationDbContext db;
        public ChanceDAO(Controller _controller)
        {
            controller = _controller;
            db = new ApplicationDbContext();
        }

        public ChanceDAO()
        {
            db = new ApplicationDbContext();
        }

        public JuegoDTO Apostar(JuegoDTO juego, UsuarioDTO usuarioDTO)
        {
            try
            {
                UsuarioDTO usuario = (UsuarioDTO)controller.Session["usuario"];
                juego.vendedorId = usuario.id;
                Chance model = ApuestaBase(juego);
                
                db.chances.Add(model);
                db.SaveChanges();

                return juego;
            }
            catch (Exception ex)
            {
                juego.codigoDeValidacion = "Error en apuesta";
                return juego;
            }
        }

        public JuegoDTO Apostar(JuegoDTO juego)
        {
            try
            {

                Chance model = ApuestaBase(juego);

                db.chances.Add(model);
                db.SaveChanges();

                return juego;
            }
            catch (Exception ex)
            {
                juego.codigoDeValidacion = "Error en apuesta "+ ex.Message;
                return juego;
            }
        }

        private Chance ApuestaBase(JuegoDTO juego)
        {
            int loteriaint = 0;
            Int32.TryParse(juego.loteria, out loteriaint);
            List<Loteria> lot = db.loterias.ToList();
            Loteria loteriaSeleccionada =  lot.FirstOrDefault(x => x.id == loteriaint);



            Chance model = new Chance();
            int cifrasint = 0;
            Int32.TryParse(juego.cifras, out cifrasint);
            model.cifras = cifrasint;
            model.codigoDeValidacion = Guid.NewGuid().ToString();
            model.fecha = DateTime.Now;
            model.serial = Guid.NewGuid().ToString();
            model.sorteo = loteriaSeleccionada.ultimoSorteo;
            model.loteriaId = loteriaSeleccionada.id;
            model.telefono = juego.telefono;
            model.vendedorId = juego.vendedorId;

            juego.apuestas.ForEach(x =>
            {
                if (x.número != 0)
                {
                    Apuesta item = new Apuesta();
                    item.combinado = x.combinado;
                    item.directo = x.directo;
                    item.numero = x.número.ToString();
                    item.pata = x.pata;
                    item.una = x.uña;
                    model.apuestas.Add(item);
                }
            });

            model.totalApuesta = model.apuestas.Sum(x => x.pata + x.una + x.directo + x.combinado).Value;
            juego.codigoDeValidacion = model.codigoDeValidacion;
            juego.serial = model.serial;
            return model;
        }

        public JuegoDTO getBySerial(string id)
        {
            try
            {
                var model = db.chances.Include(x => x.apuestas).Include(x => x.loteria).Include(x => x.vendedor).FirstOrDefault(x => x.serial == id.Trim());
                if (model == null)
                { throw new Exception("serial no existe"); }

                JuegoDTO result = new JuegoDTO();
                result.cifras = model.cifras.ToString();
                result.codigoDeValidacion = model.codigoDeValidacion;
                result.loteria = model.loteria.nombre;
                result.fecha = model.fecha;
                result.fechaSorteo = model.loteria.proximoSorteo;
                result.sorteo = model.sorteo;

                result.serial = id;
                result.telefono = model.telefono;
                result.vendedorId = model.vendedorId;
                result.vendedor = model.vendedor.nombre;
                model.apuestas.ForEach(x => {
                    ApuestaDTO item = new ApuestaDTO();
                    item.combinado = x.combinado.Value;
                    item.directo = x.directo;
                    item.número = int.Parse(x.numero);
                    item.pata = x.pata.Value;
                    item.uña = x.una.Value;
                    result.apuestas.Add(item);
                });
                result.totalApuesta = model.totalApuesta;
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
