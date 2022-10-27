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
    public class PermisosController : Controller
    {
        private DColorEntities db = new DColorEntities();

        // GET: Permisos
        public async Task<ActionResult> Index()
        {
            var rol_Operacions = db.Rol_Operacions.Include(r => r.Operacione).Include(r => r.Rol);
            return View(await rol_Operacions.ToListAsync());
        }

        // GET: Permisos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Operacion rol_Operacion = await db.Rol_Operacions.FindAsync(id);
            if (rol_Operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_Operacion);
        }

        // GET: Permisos/Create
        public ActionResult Create()
        {
            ViewBag.idOperacion = new SelectList(db.Operaciones, "id", "nombre");
            ViewBag.idRol = new SelectList(db.Rols, "idRol", "nombre");
            return View();
        }

        // POST: Permisos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,idRol,idOperacion")] Rol_Operacion rol_Operacion)
        {
            if (ModelState.IsValid)
            {
                db.Rol_Operacions.Add(rol_Operacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idOperacion = new SelectList(db.Operaciones, "id", "nombre", rol_Operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.Rols, "idRol", "nombre", rol_Operacion.idRol);
            return View(rol_Operacion);
        }

        // GET: Permisos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Operacion rol_Operacion = await db.Rol_Operacions.FindAsync(id);
            if (rol_Operacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idOperacion = new SelectList(db.Operaciones, "id", "nombre", rol_Operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.Rols, "idRol", "nombre", rol_Operacion.idRol);
            return View(rol_Operacion);
        }

        // POST: Permisos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,idRol,idOperacion")] Rol_Operacion rol_Operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol_Operacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idOperacion = new SelectList(db.Operaciones, "id", "nombre", rol_Operacion.idOperacion);
            ViewBag.idRol = new SelectList(db.Rols, "idRol", "nombre", rol_Operacion.idRol);
            return View(rol_Operacion);
        }

        // GET: Permisos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol_Operacion rol_Operacion = await db.Rol_Operacions.FindAsync(id);
            if (rol_Operacion == null)
            {
                return HttpNotFound();
            }
            return View(rol_Operacion);
        }

        // POST: Permisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rol_Operacion rol_Operacion = await db.Rol_Operacions.FindAsync(id);
            db.Rol_Operacions.Remove(rol_Operacion);
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
