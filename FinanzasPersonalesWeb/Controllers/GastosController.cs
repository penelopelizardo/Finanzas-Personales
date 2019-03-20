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
    public class GastosController : Controller
    {
        private Model1 db = new Model1();

        // GET: Gastos
        public ActionResult Index()
        {
            var gastos = db.Gastos.Include(g => g.Cuentas).Include(g => g.TiposIngresos);
            return View(gastos.ToList());
        }

        // GET: Gastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            return View(gastos);
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            ViewBag.GastoCuenta = new SelectList(db.Cuentas, "CuentaId", "CuentaDescripcion");
            ViewBag.GastoTipo = new SelectList(db.TiposIngresos, "TipoIngresoId", "TipoIngresoDescripcion");
            return View();
        }

        // POST: Gastos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GastoId,GastoDescripcion,GastoMonto,GastoFecha,GastoRecurrente,GastoRecurrenteFhLimite,GastoTipo,GastoCuenta")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                db.Gastos.Add(gastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GastoCuenta = new SelectList(db.Cuentas, "CuentaId", "CuentaDescripcion", gastos.GastoCuenta);
            ViewBag.GastoTipo = new SelectList(db.TiposIngresos, "TipoIngresoId", "TipoIngresoDescripcion", gastos.GastoTipo);
            return View(gastos);
        }

        // GET: Gastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            ViewBag.GastoCuenta = new SelectList(db.Cuentas, "CuentaId", "CuentaDescripcion", gastos.GastoCuenta);
            ViewBag.GastoTipo = new SelectList(db.TiposIngresos, "TipoIngresoId", "TipoIngresoDescripcion", gastos.GastoTipo);
            return View(gastos);
        }

        // POST: Gastos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GastoId,GastoDescripcion,GastoMonto,GastoFecha,GastoRecurrente,GastoRecurrenteFhLimite,GastoTipo,GastoCuenta")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GastoCuenta = new SelectList(db.Cuentas, "CuentaId", "CuentaDescripcion", gastos.GastoCuenta);
            ViewBag.GastoTipo = new SelectList(db.TiposIngresos, "TipoIngresoId", "TipoIngresoDescripcion", gastos.GastoTipo);
            return View(gastos);
        }

        // GET: Gastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.Gastos.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            return View(gastos);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gastos gastos = db.Gastos.Find(id);
            db.Gastos.Remove(gastos);
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
