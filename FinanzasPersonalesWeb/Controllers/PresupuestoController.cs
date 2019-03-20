using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinanzasPersonalesWeb.Models;

namespace FinanzasPersonalesWeb.Controllers
{
    public class PresupuestoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Presupuesto
        public ActionResult Index()
        {
            var presupuesto = db.Presupuesto.Include(p => p.Monedas);
            return View(presupuesto.ToList());
        }

        // GET: Presupuesto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.Presupuesto.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // GET: Presupuesto/Create
        public ActionResult Create()
        {
            ViewBag.PresupuestoTipoMoneda = new SelectList(db.Monedas, "MonedaId", "MonedaDescripcion");
            return View();
        }

        // POST: Presupuesto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PresupuestoId,PresupuestoDescripcion,PresupuestoMonto,PresupuestoTipoMoneda,PresupuestoFhActualizacion,PresupuestoFhCreacion")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.Presupuesto.Add(presupuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PresupuestoTipoMoneda = new SelectList(db.Monedas, "MonedaId", "MonedaDescripcion", presupuesto.PresupuestoTipoMoneda);
            return View(presupuesto);
        }

        // GET: Presupuesto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.Presupuesto.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            ViewBag.PresupuestoTipoMoneda = new SelectList(db.Monedas, "MonedaId", "MonedaDescripcion", presupuesto.PresupuestoTipoMoneda);
            return View(presupuesto);
        }

        // POST: Presupuesto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PresupuestoId,PresupuestoDescripcion,PresupuestoMonto,PresupuestoTipoMoneda,PresupuestoFhActualizacion,PresupuestoFhCreacion")] Presupuesto presupuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presupuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PresupuestoTipoMoneda = new SelectList(db.Monedas, "MonedaId", "MonedaDescripcion", presupuesto.PresupuestoTipoMoneda);
            return View(presupuesto);
        }

        // GET: Presupuesto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Presupuesto presupuesto = db.Presupuesto.Find(id);
            if (presupuesto == null)
            {
                return HttpNotFound();
            }
            return View(presupuesto);
        }

        // POST: Presupuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Presupuesto presupuesto = db.Presupuesto.Find(id);
            db.Presupuesto.Remove(presupuesto);
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
