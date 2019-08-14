
using Servicios.DAO;
using Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monedas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult login(string usuario, string contrasena)
        {
            try
            {
                ViewBag.usuario = usuario;
                ViewBag.isUsuario = contrasena;
                Servicios.DAO.LoginDAO login = new Servicios.DAO.LoginDAO(this);
                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO.usuario = usuario;
                usuarioDTO.contrasena = contrasena;
                if (login.login(usuarioDTO))
                {
                    Session.Add("usuario", usuarioDTO);
                    ViewBag.loterias = new SelectList(login.getLoterias(), "id", "nombre"); 
                    return View("Juego");
                }
                else
                {
                    ViewBag.message = "usuario o contraseña errada";
                    return View("Index");
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Ticket(string id)
        {
            try
            {
                UsuarioDTO usuarioDTO = (UsuarioDTO)Session["usuario"];
                if (usuarioDTO == null)
                { return View("Index"); }
                ChanceDAO chance = new ChanceDAO(this);
                JuegoDTO juegoCreado = chance.getBySerial(id);
                return View(juegoCreado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Apostar(JuegoDTO juego)
        {
            try
            {
                UsuarioDTO usuarioDTO = (UsuarioDTO)Session["usuario"];
                ChanceDAO chance = new ChanceDAO(this);

                JuegoDTO juegoCreado = chance.Apostar(juego, usuarioDTO);

                return Json(juegoCreado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult Juego()
        {
            try
            {
                Servicios.DAO.LoginDAO login = new Servicios.DAO.LoginDAO(this);
                ViewBag.loterias = new SelectList(login.getLoterias(), "id", "nombre");
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
