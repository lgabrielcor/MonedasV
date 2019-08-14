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
    public class SorteosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sorteos
        public ActionResult Index()
        {
            var sorteo = db.sorteo.Include(s => s.loteria);
            return View(sorteo.ToList());
        }

        // GET: Sorteos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteo sorteo = db.sorteo.Find(id);
            if (sorteo == null)
            {
                return HttpNotFound();
            }
            return View(sorteo);
        }

        // GET: Sorteos/Create
        public ActionResult Create()
        {
            ViewBag.loteriaId = new SelectList(db.loterias, "id", "nombre");
            return View();
        }

        // POST: Sorteos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,numeroDeSorteo,numero,fecha,loteriaId")] Sorteo sorteo)
        {
            if (ModelState.IsValid)
            {
                db.sorteo.Add(sorteo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.loteriaId = new SelectList(db.loterias, "id", "nombre", sorteo.loteriaId);
            return View(sorteo);
        }

        // GET: Sorteos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteo sorteo = db.sorteo.Find(id);
            if (sorteo == null)
            {
                return HttpNotFound();
            }
            ViewBag.loteriaId = new SelectList(db.loterias, "id", "nombre", sorteo.loteriaId);
            return View(sorteo);
        }

        // POST: Sorteos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,numeroDeSorteo,numero,fecha,loteriaId")] Sorteo sorteo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sorteo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.loteriaId = new SelectList(db.loterias, "id", "nombre", sorteo.loteriaId);
            return View(sorteo);
        }

        // GET: Sorteos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteo sorteo = db.sorteo.Find(id);
            if (sorteo == null)
            {
                return HttpNotFound();
            }
            return View(sorteo);
        }

        // POST: Sorteos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sorteo sorteo = db.sorteo.Find(id);
            db.sorteo.Remove(sorteo);
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
