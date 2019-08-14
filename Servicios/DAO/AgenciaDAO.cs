using Model;
using Persistencia;
using Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Servicios.DAO
{
    public class AgenciaDAO
    {

        private Controller controller;
        private ApplicationDbContext db;
        public AgenciaDAO(Controller _controller)
        {
            controller = _controller;
            db = new ApplicationDbContext();
        }

        public List<AgenciaDTO> list()
        {
            try
            {
                List<AgenciaDTO> result = new List<AgenciaDTO>();
                var model = db.Agencias.ToList();

                model.ForEach(x =>
                {
                    AgenciaDTO item = new AgenciaDTO();
                    item.estado = x.estado;
                    item.id = x.id;
                    item.nombre = x.nombre;
                    item.nit = x.nit;
                    item.nombreRepresentanteLegal = x.nombreRepresentanteLegal;
                    item.cedulaRepresentanteLegal = x.cedulaRepresentanteLegal;
                    item.direccion = x.direccion;
                    item.telefono = x.telefono;
                    item.administradores = x.administradores;
                    item.vendedores = x.vendedores;


                    result.Add(item);
                });

                return result;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public AgenciaDTO Detalles(int? id)
        {
            try
            {
                var model = db.Agencias.Find(id);
                AgenciaDTO item = new AgenciaDTO();
                item.estado = model.estado;
                item.id = model.id;
                item.nombre = model.nombre;
                item.nit = model.nit;
                item.nombreRepresentanteLegal = model.nombreRepresentanteLegal;
                item.cedulaRepresentanteLegal = model.cedulaRepresentanteLegal;
                item.direccion = model.direccion;
                item.telefono = model.telefono;
                item.administradores = model.administradores;
                item.vendedores = model.vendedores;

                return item;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Create(AgenciaDTO agencia)
        {
            try
            {
                Agencia item = new Agencia();
                item.estado = agencia.estado;
                item.id = agencia.id;
                item.nombre = agencia.nombre;
                item.nit = agencia.nit;
                item.nombreRepresentanteLegal = agencia.nombreRepresentanteLegal;
                item.cedulaRepresentanteLegal = agencia.cedulaRepresentanteLegal;
                item.direccion = agencia.direccion;
                item.telefono = agencia.telefono;
                item.administradores = agencia.administradores;
                item.vendedores = agencia.vendedores;

                db.Agencias.Add(item);
                db.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }

        }
        
        public void Edit(AgenciaDTO agencia)
        {
            try
            {
                Agencia item = new Agencia();
                item.estado = agencia.estado;
                item.id = agencia.id;
                item.nombre = agencia.nombre;
                item.nit = agencia.nit;
                item.nombreRepresentanteLegal = agencia.nombreRepresentanteLegal;
                item.cedulaRepresentanteLegal = agencia.cedulaRepresentanteLegal;
                item.direccion = agencia.direccion;
                item.telefono = agencia.telefono;
                item.administradores = agencia.administradores;
                item.vendedores = agencia.vendedores;

                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void Deshabilitar(AgenciaDTO agencia)
        {
            try
            {
                
                var agenciaModel = db.Agencias.Find(agencia.id);
                agenciaModel.estado = false;

                db.Entry(agenciaModel).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
    }
}