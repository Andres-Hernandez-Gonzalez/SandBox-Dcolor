using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ClosedXML.Excel;
using DColor.DB;
using Rotativa;

namespace DColor.Controllers
{
    public class EmpleadosController : Controller
    {
        private DColorEntities db = new DColorEntities();

        // GET: Empleadoes
        public ActionResult Index()
        {
            var empleadoes = db.Empleadoes.Include(e => e.Estado_Empleado).Include(e => e.Rol);
            return View(empleadoes.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.Estado_Empleadoes, "idEstado", "estadoEmpleado");
            ViewBag.idRol = new SelectList(db.Rols, "idRol", "nombre");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleado,idRol,idEstado,nombre,apellido,correo,cedula,contraseña,tokenRecovery,telefono,intentos,ultimoIntento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleadoes.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.Estado_Empleadoes, "idEstado", "estadoEmpleado", empleado.idEstado);
            ViewBag.idRol = new SelectList(db.Rols, "idRol", "nombre", empleado.idRol);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.Estado_Empleadoes, "idEstado", "estadoEmpleado", empleado.idEstado);
            ViewBag.idRol = new SelectList(db.Rols, "idRol", "nombre", empleado.idRol);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleado,idRol,idEstado,nombre,apellido,correo,cedula,contraseña,tokenRecovery,telefono,intentos,ultimoIntento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.Estado_Empleadoes, "idEstado", "estadoEmpleado", empleado.idEstado);
            ViewBag.idRol = new SelectList(db.Rols, "idRol", "nombre", empleado.idRol);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleadoes.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleadoes.Find(id);
            db.Empleadoes.Remove(empleado);
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

        public ActionResult ReportePdf()
        {
            var empleadoes = db.Empleadoes.Include(e => e.Estado_Empleado).Include(e => e.Rol);
            return View(empleadoes);
        }

        public ActionResult Print()
        {
            return new ActionAsPdf("ReportePdf") { FileName = "Reporte General de Empleados" };
        }


        [HttpPost]
        public FileResult GenerarExcel()
        {
            DColorEntities entities = new DColorEntities();
            DataTable dt = new DataTable("Reporte General de Empleados");
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Rol Empleado"),
                                            new DataColumn("Cedula"),
                                            new DataColumn("Nombre"),
                                            new DataColumn("Apellidos"),
                                            new DataColumn("Telefono"),
                                            new DataColumn("Correo"),
                                            new DataColumn("Estado Empleado") });

            var empleadoes = db.Empleadoes.Include(e => e.Estado_Empleado).Include(e => e.Rol);

            foreach (var db in empleadoes)
            {
                dt.Rows.Add(db.Rol.nombre, db.cedula, db.nombre, db.apellido, db.telefono, db.correo, db.Estado_Empleado.estadoEmpleado);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reporte General de Empleados.xlsx");
                }
            }
        }
    }
}
