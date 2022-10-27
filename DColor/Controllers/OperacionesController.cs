using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DColor.DB;

namespace DColor.Controllers
{
    public class OperacionesController : Controller
    {
        private DColorEntities db = new DColorEntities();

        // GET: Operaciones
        public async Task<ActionResult> Index()
        {
            var operaciones = db.Operaciones.Include(o => o.Modulo);
            return View(await operaciones.ToListAsync());
        }

        // GET: Operaciones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacione operacione = await db.Operaciones.FindAsync(id);
            if (operacione == null)
            {
                return HttpNotFound();
            }
            return View(operacione);
        }

        // GET: Operaciones/Create
        public ActionResult Create()
        {
            ViewBag.idModulo = new SelectList(db.Moduloes, "idModulo", "nombre");
            return View();
        }

        // POST: Operaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,idModulo")] Operacione operacione)
        {
            if (ModelState.IsValid)
            {
                db.Operaciones.Add(operacione);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idModulo = new SelectList(db.Moduloes, "idModulo", "nombre", operacione.idModulo);
            return View(operacione);
        }

        // GET: Operaciones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacione operacione = await db.Operaciones.FindAsync(id);
            if (operacione == null)
            {
                return HttpNotFound();
            }
            ViewBag.idModulo = new SelectList(db.Moduloes, "idModulo", "nombre", operacione.idModulo);
            return View(operacione);
        }

        // POST: Operaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,idModulo")] Operacione operacione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operacione).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idModulo = new SelectList(db.Moduloes, "idModulo", "nombre", operacione.idModulo);
            return View(operacione);
        }

        // GET: Operaciones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacione operacione = await db.Operaciones.FindAsync(id);
            if (operacione == null)
            {
                return HttpNotFound();
            }
            return View(operacione);
        }

        // POST: Operaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Operacione operacione = await db.Operaciones.FindAsync(id);
            db.Operaciones.Remove(operacione);
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
