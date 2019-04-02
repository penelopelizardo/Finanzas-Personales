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
    public class DeudasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Deudas
        public ActionResult Index()
        {
            var deudas = db.Deudas.Include(d => d.Monedas);
            return View(deudas.ToList());
        }

        // GET: Deudas/Details/5
        public JsonResult GetDeudaById(int? id)
        {
            if (id == 0)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transacciones = (from t in db.Transacciones
                                 where t.TranId == id
                                 select t
                           ).ToList().Select(obj => new Transacciones
                           {
                               TranId = obj.TranId,
                               TranDescripcion = obj.TranDescripcion,
                               TranFh = obj.TranFecha.ToString(),
                               TranMonto = obj.TranMonto,
                               TranRecurrente = obj.TranRecurrente,
                               TranFhLimite = obj.TranRecurrenteFhLimite.ToString(),
                               TranTipo = obj.TranTipo,
                               TranCuenta = obj.TranCuenta

                           }).FirstOrDefault();
            if (transacciones == null)
            {
                //return HttpNotFound();
            }
            return Json(transacciones);
        }

        // POST: Deudas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(Deudas deudas)
        {
            if (ModelState.IsValid)
            {
                db.Deudas.Add(deudas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deudas);
        }

        // GET: Deudas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deudas deudas = db.Deudas.Find(id);
            if (deudas == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeudaTipoMoneda = new SelectList(db.Monedas, "MonedaId", "MonedaDescripcion", deudas.DeudaTipoMoneda);
            return View(deudas);
        }

        // POST: Deudas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Deudas deudas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deudas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deudas);
        }

        // GET: Deudas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deudas deudas = db.Deudas.Find(id);
            if (deudas == null)
            {
                return HttpNotFound();
            }
            return View(deudas);
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
