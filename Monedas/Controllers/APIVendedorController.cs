using Monedas.Models;
using Servicios.DAO;
using Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Monedas.Controllers
{
    public class APIVendedorController : ApiController
    {

        public UsuarioDTO login([FromBody]LoginDTO usuario)
        {
            try
            {
                Servicios.DAO.LoginDAO login = new Servicios.DAO.LoginDAO();
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO.usuario = usuario.usuario;
                usuarioDTO.contrasena = usuario.password;
                if (login.login(usuarioDTO))
                {
                    //ViewBag.loterias = new SelectList(login.getLoterias(), "id", "nombre");
                    return usuarioDTO;
                }
                else
                {
                    var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Usuario no autorizado" };
                    throw new HttpResponseException(msg);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public JuegoDTO Apostar([FromBody]JuegoDTO juego)
        {
            try
            {
                ChanceDAO chance = new ChanceDAO();
                JuegoDTO result = chance.Apostar(juego);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<LoteriaDTO> getLoterias()
        {
            try
            {
                Servicios.DAO.LoginDAO login = new Servicios.DAO.LoginDAO();
                return login.getLoterias();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
