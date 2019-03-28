using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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

            CultureInfo culture = new CultureInfo("en-US");
            transacciones.TranFecha = DateTime.Now;
            //transacciones.TranFecha = DateTime.ParseExact(transacciones.TranFh, "dd/MM/yyyy HH:mm tt", CultureInfo.InvariantCulture);
            //transacciones.TranRecurrenteFhLimite = Convert.ToDateTime(transacciones.TranFhLimite);

            //var monto = Regex.Replace(transacciones.TranMonto.ToString(), ",", "");

            //transacciones.TranMonto = decimal.Parse(monto);

            ModelState.Remove("TranId");

            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transacciones);
                db.SaveChanges();

            }

            return Json(transacciones);
        }

        // GET: Transacciones/Edit/5
        public JsonResult GetTransactionsById(int id)
        {
            if (id == 0)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Transacciones transacciones = db.Transacciones.Find(id);
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
