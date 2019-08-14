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

namespace Monedero.Controllers
{
    public class ChancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Chances
        public async Task<ActionResult> Index()
        {
            var chances = db.chances.Include(c => c.loteria).Include(c => c.vendedor);
            return View(await chances.ToListAsync());
        }

        // GET: Chances/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chance chance = await db.chances.Include(c => c.loteria).Include(c => c.vendedor).Include(c => c.apuestas).FirstOrDefaultAsync(x => x.id == id);
            if (chance == null)
            {
                return HttpNotFound();
            }
            return View(chance);
        }

        // GET: Chances/Create
        public ActionResult Create()
        {
            ViewBag.loteriaId = new SelectList(db.loterias, "id", "nombre");
            ViewBag.vendedorId = new SelectList(db.vendedores, "id", "nombre");
            return View();
        }

        // POST: Chances/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,loteriaId,fecha,sorteo,totalApuesta,telefono,serial,codigoDeValidacion,cifras,vendedorId")] Chance chance)
        {
            if (ModelState.IsValid)
            {
                db.chances.Add(chance);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.loteriaId = new SelectList(db.loterias, "id", "nombre", chance.loteriaId);
            ViewBag.vendedorId = new SelectList(db.vendedores, "id", "nombre", chance.vendedorId);
            return View(chance);
        }

        // GET: Chances/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chance chance = await db.chances.FindAsync(id);
            if (chance == null)
            {
                return HttpNotFound();
            }
            ViewBag.loteriaId = new SelectList(db.loterias, "id", "nombre", chance.loteriaId);
            ViewBag.vendedorId = new SelectList(db.vendedores, "id", "nombre", chance.vendedorId);
            return View(chance);
        }

        // POST: Chances/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,loteriaId,fecha,sorteo,totalApuesta,telefono,serial,codigoDeValidacion,cifras,vendedorId")] Chance chance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chance).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.loteriaId = new SelectList(db.loterias, "id", "nombre", chance.loteriaId);
            ViewBag.vendedorId = new SelectList(db.vendedores, "id", "nombre", chance.vendedorId);
            return View(chance);
        }

        // GET: Chances/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chance chance = await db.chances.FindAsync(id);
            if (chance == null)
            {
                return HttpNotFound();
            }
            return View(chance);
        }

        // POST: Chances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Chance chance = await db.chances.FindAsync(id);
            db.chances.Remove(chance);
            await db.SaveChangesAsync();
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
