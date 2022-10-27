using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DColor;
using Rotativa;

namespace DColor.Controllers
{
    public class ClientesController : Controller
    {
        private DColorEntities db = new DColorEntities();

        // GET: Clientes
        public async Task<ActionResult> ConsultarClientes()
        {
            var clientes = db.Clientes.Include(c => c.EstadoCliente);
            return View(await clientes.ToListAsync());
        }

       
        // GET: Clientes/Create
        public ActionResult RegistrarClientes()
        {
            ViewBag.idEstadoCliente = new SelectList(db.EstadoClientes, "idEstadoCliente", "estadoCliente");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegistrarClientes([Bind(Include = "idCliente,nombre,apellidos,direccion,telefono,correo,cedula,idEstadoCliente")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                await db.SaveChangesAsync();
                return RedirectToAction("ConsultarClientes");
            }

            ViewBag.idEstadoCliente = new SelectList(db.EstadoClientes, "idEstadoCliente", "estadoCliente", cliente.idEstadoCliente);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<ActionResult> ModificarClientes(int? idCliente)
        {
            if (idCliente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Clientes.FindAsync(idCliente);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadoCliente = new SelectList(db.EstadoClientes, "idEstadoCliente", "estadoCliente", cliente.idEstadoCliente);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ModificarClientes([Bind(Include = "idCliente,nombre,apellidos,direccion,telefono,correo,cedula,idEstadoCliente")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("ConsultarClientes");
            }
            ViewBag.idEstadoCliente = new SelectList(db.EstadoClientes, "idEstadoCliente", "estadoCliente", cliente.idEstadoCliente);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<ActionResult> EliminarClientes(int? idCliente)
        {
            if (idCliente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = await db.Clientes.FindAsync(idCliente);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("EliminarClientes")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmarEliminacionClientes(int idCliente)
        {
            Cliente cliente = await db.Clientes.FindAsync(idCliente);
            db.Clientes.Remove(cliente);
            await db.SaveChangesAsync();
            return RedirectToAction("ConsultarClientes");
        }
        
        public ActionResult ReportePdf()
        {
            var clientes = db.Clientes.Include(c => c.EstadoCliente);
            return View(clientes);
        }

        public ActionResult Print()
        {
            return new ActionAsPdf("ReportePdf") { FileName = "Reporte General de Clientes" };
        }


    }
}
