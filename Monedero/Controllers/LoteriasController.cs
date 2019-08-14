using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model;
using Persistencia;

namespace Monedero.Controllers
{
    public class LoteriasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Loterias
        public ActionResult Index()
        {
            return View(db.loterias.ToList());
        }

        // GET: Loterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loteria loteria = db.loterias.Find(id);
            if (loteria == null)
            {
                return HttpNotFound();
            }
            return View(loteria);
        }

        // GET: Loterias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loterias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,diaDeJuego,horaDeCierre,ultimoSorteo,estado,codigoBase")] Loteria loteria)
        {
            if (ModelState.IsValid)
            {
                db.loterias.Add(loteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loteria);
        }

        // GET: Loterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loteria loteria = db.loterias.Find(id);
            if (loteria == null)
            {
                return HttpNotFound();
            }
            return View(loteria);
        }

        // POST: Loterias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,diaDeJuego,horaDeCierre,ultimoSorteo,estado,codigoBase")] Loteria loteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loteria);
        }

        // GET: Loterias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loteria loteria = db.loterias.Find(id);
            if (loteria == null)
            {
                return HttpNotFound();
            }
            return View(loteria);
        }

        // POST: Loterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loteria loteria = db.loterias.Find(id);
            db.loterias.Remove(loteria);
            db.SaveChanges();
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
