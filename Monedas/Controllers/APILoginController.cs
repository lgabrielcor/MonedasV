using Monedas.Models;
using Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Monedas.Controllers
{
    public class APILoginController : ApiController
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
    }
}
