using Persistencia;
using Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using Model;

namespace Servicios.DAO
{
    public class LoginDAO
    {
        ApplicationDbContext db;
        public Controller controller { get; set; }
        public LoginDAO(Controller _controller)
        {
            controller = _controller;
            db = new ApplicationDbContext();
        }
        public LoginDAO()
        {
            db = new ApplicationDbContext();
        }
        public bool login(Servicios.DTO.UsuarioDTO usuario)
        {
            Vendedor existe = db.vendedores.FirstOrDefault(x => x.usuario.Trim().ToLower().Equals(usuario.usuario.Trim().ToLower())
            && x.password.Trim().Equals(usuario.contrasena.Trim())
            );

            usuario.id = existe.id;
            
            return existe!= null;
        }

        public List<LoteriaDTO> getLoterias()
        {
            try
            {
                List<Loteria> model =  db.loterias.ToList();
                List<LoteriaDTO> loterias = new List<LoteriaDTO>();

                model.ForEach(x => {
                    LoteriaDTO item = new LoteriaDTO();
                    item.estado = x.estado;
                    item.id = x.id;
                    item.nombre = x.nombre;
                    item.proximoSorteo = x.proximoSorteo;
                    loterias.Add(item);
                });

                return loterias;
            }           
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
