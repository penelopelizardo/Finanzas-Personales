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

        // POST: Gastos/Create
        [HttpPost]
        public JsonResult Create(Gastos gastos)
        {
            gastos.GastoRecurrente = false;
            gastos.GastoFecha = DateTime.Now;

            ModelState.Remove("GastoId");

            if (ModelState.IsValid)
            {
                db.Gastos.Add(gastos);
                db.SaveChanges();
            }

            return Json(gastos);
        }

        // GET: Gastos/Edit/5
        public JsonResult GetGastosById(int id)
        {
            if (id == 0)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Gastos gastos = db.Gastos.Find(id);

            var gastos = (from t in db.Gastos
                          where t.GastoId == id
                          select t
                                 ).ToList().Select(obj => new Gastos
                                 {
                                     GastoId = obj.GastoId,
                                     GastoDescripcion = obj.GastoDescripcion,
                                     GastoFecha = obj.GastoFecha,
                                     GastoMonto = obj.GastoMonto,
                                     GastoRecurrente = obj.GastoRecurrente,
                                     GastoRecurrenteFhLimite = obj.GastoRecurrenteFhLimite,
                                     GastoTipo = obj.GastoTipo,
                                     GastoCuenta = obj.GastoCuenta

                                 }).FirstOrDefault();
            if (gastos == null)
            {
                //return HttpNotFound();
            }
            return Json(gastos, JsonRequestBehavior.AllowGet);
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        public JsonResult Edit(Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gastos).State = EntityState.Modified;
                db.SaveChanges();
            }
           
            return Json(gastos);
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
