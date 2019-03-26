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
    public class TransaccionesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Transacciones
        public ActionResult Index()
        {
            var transacciones = db.Transacciones.Include(t => t.Cuentas).ToList();
            return View(transacciones);
        }
             

        // POST: Transacciones/Create
        [HttpPost]
        public JsonResult Create(Transacciones transacciones)
        {
            transacciones.TranRecurrente = false;
            transacciones.TranFecha = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transacciones);
                db.SaveChanges();

            }

            return Json(transacciones);
        }

        // GET: Transacciones/Edit/5
        public JsonResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Transacciones transacciones = db.Transacciones.Find(id);
            var transacciones = (from t in db.Transacciones
                                 where t.TranId == id
                                 select t
                                 ).ToList().Select(obj => new Transacciones
                                 {
                                    TranDescripcion = obj.TranDescripcion,
                                     TranFecha=  obj.TranFecha,
                                     TranMonto= obj.TranMonto,
                                     TranRecurrente= obj.TranRecurrente,
                                     TranRecurrenteFhLimite =  obj.TranRecurrenteFhLimite,
                                     TranTipo = obj.TranTipo,
                                     TranCuenta = obj.TranCuenta

                                 }).FirstOrDefault();

            if (transacciones == null)
            {
                //return HttpNotFound();
            }
            return Json(transacciones, JsonRequestBehavior.AllowGet);
        }

        // POST: Transacciones/Edit/5
        [HttpPost]
        public JsonResult Edit(Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacciones).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Json(transacciones);
        }

        public JsonResult GetCuentas()
        {
            var resultado = (from t in db.Cuentas
                             select t
                          ).ToList().Select(obj => new Cuentas
                          {
                              CuentaId = obj.CuentaId,
                              CuentaDescripcion = obj.CuentaDescripcion
                          }).ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
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
