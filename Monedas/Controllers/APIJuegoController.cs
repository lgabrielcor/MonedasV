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
    public class APIJuegoController : ApiController
    {

        public JuegoDTO Apostar(JuegoDTO juego)
        {
            try
            {

                ChanceDAO chance = new ChanceDAO();
                JuegoDTO result = chance.Apostar(juego);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
