using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Persistencia;
using Servicios.DAO;
using Servicios.DTO;

namespace Monedero.Controllers
{
    public class AgenciasController : Controller

    {   private AgenciaDAO  AgenciasDAO;
        private ApplicationDbContext db = new ApplicationDbContext();

        public AgenciasController()
        {
            AgenciasDAO = new AgenciaDAO(this);
        }

        // GET: Agencias
        public ActionResult Index()
        {
            List<AgenciaDTO> agencias = AgenciasDAO.list();
            return View(agencias);
        }

        // GET: Agencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenciaDTO agencia = AgenciasDAO.Detalles(id);

            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // GET: Agencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,nit,nombreRepresentanteLegal,cedulaRepresentanteLegal,direccion,telefono,estado")] AgenciaDTO agencia)
        {
            if (ModelState.IsValid)
            {
                AgenciasDAO.Create(agencia);
                return RedirectToAction("Index");
            }

            return View(agencia);
        }

        // GET: Agencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenciaDTO agencia = AgenciasDAO.Detalles(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: Agencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,nit,nombreRepresentanteLegal,cedulaRepresentanteLegal,direccion,telefono,estado")] AgenciaDTO agencia)
        {
            if (ModelState.IsValid)
            {
                AgenciasDAO.Edit(agencia);
                return RedirectToAction("Index");
            }
            return View(agencia);
        }

        // GET: Agencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenciaDTO agencia = AgenciasDAO.Detalles(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: Agencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgenciaDTO agencia = AgenciasDAO.Detalles(id);
            AgenciasDAO.Deshabilitar(agencia); 
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
