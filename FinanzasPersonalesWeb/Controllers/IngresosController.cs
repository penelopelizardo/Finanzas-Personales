using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinanzasPersonalesWeb.Models;

namespace FinanzasPersonalesWeb.Controllers
{
    public class IngresosController : Controller
    {
        private Model1 db = new Model1();

        // GET: Ingresos
        public ActionResult Index()
        {
            return View(db.Ingresos.ToList());
        }

        // POST: Ingresos/Create
        [HttpPost]
        public JsonResult Create(Ingresos ingresos)
        {
            ingresos.IngresoRecurrente = false;
            ingresos.IngresoFecha = DateTime.Now; 
            //CultureInfo culture = new CultureInfo("en-US");
            //ingresos.IngresoFecha = DateTime.ParseExact(ingresos.IngresoFh, "dd/MM/yyyy HH:mm tt", culture);

            ModelState.Remove("IngresoId");

            if (ModelState.IsValid)
            {
                db.Ingresos.Add(ingresos);
                db.SaveChanges();
            }

            return Json(ingresos);
        }

        // GET: Ingresos/Edit/5
        public JsonResult GetIngresosById(int id)
        {
            if (id == 0)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ingresos = (from t in db.Ingresos
                            where t.IngresoId == id
                            select t
                                  ).ToList().Select(obj => new Ingresos
                                  {
                                      IngresoId = obj.IngresoId,
                                      IngresoTipo = obj.IngresoTipo,
                                      IngresoFh = obj.IngresoFecha.ToString(),
                                      IngresoMonto = obj.IngresoMonto,
                                      IngresoDescripcion = obj.IngresoDescripcion,
                                      //IngresoRecurrente = obj.IngresoRecurrente,
                                      //IngresoFhLimite = obj.IngresoRecurrenteFhLimite.ToString(),
                                      IngresoCuenta = obj.IngresoCuenta

                                  }).FirstOrDefault();
            if (ingresos == null)
            {
                //return HttpNotFound();
            }
            return Json(ingresos, JsonRequestBehavior.AllowGet);
        }

        // POST: Ingresos/Edit/5
        [HttpPost]
        public JsonResult Edit(Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresos).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(ingresos);
        }

        // GET: Ingresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresos ingresos = db.Ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            return View(ingresos);
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
