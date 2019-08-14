using Servicios.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Monedas.Controllers
{
    public class APILoteriasController : ApiController
    {
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
