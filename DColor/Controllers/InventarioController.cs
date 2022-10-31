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
    public class InventarioController : Controller
    {
        private DColorEntities db = new DColorEntities();



        // GET: Inventario
        public async Task<ActionResult> Index()
        {
            var insumos = db.Insumos.Include(i => i.Proveedor);
            return View(await insumos.ToListAsync());
        }

        // GET: Inventario/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = await db.Insumos.FindAsync(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // GET: Inventario/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre");
            return View();
        }

        // POST: Inventario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idProducto,idProveedor,nombre,marca,cantidad,precio")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Insumos.Add(insumo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", insumo.idProveedor);
            return View(insumo);
        }

        // GET: Inventario/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = await db.Insumos.FindAsync(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", insumo.idProveedor);
            return View(insumo);
        }

        // POST: Inventario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idProducto,idProveedor,nombre,marca,cantidad,precio")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.Proveedors, "idProveedor", "nombre", insumo.idProveedor);
            return View(insumo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditNB(Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insumo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(insumo);
        }

        // GET: Inventario/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insumo insumo = await db.Insumos.FindAsync(id);
            if (insumo == null)
            {
                return HttpNotFound();
            }
            return View(insumo);
        }

        // POST: Inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Insumo insumo = await db.Insumos.FindAsync(id);
            db.Insumos.Remove(insumo);
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
