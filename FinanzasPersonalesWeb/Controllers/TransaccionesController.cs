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
            var transacciones = db.Transacciones.Include(t => t.TransaccionesTipos).Include(t=> t.Cuentas).ToList();
            return View(transacciones);
        }

        // GET: Transacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // GET: Transacciones/Create
        public ActionResult Create()
        {
            ViewBag.TranTipo = new SelectList(db.TransaccionesTipos, "TranTiposId", "TranTiposDescripcion");
            ViewBag.TranCuenta = new SelectList(db.Cuentas, "CuentaId", "CuentaDescripcion");
            return View();
        }

        // POST: Transacciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transacciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TranTipo = new SelectList(db.TransaccionesTipos, "TranTiposId", "TranTiposDescripcion", transacciones.TranTipo);
            ViewBag.TranCuenta = new SelectList(db.Cuentas, "CuentaId", "CuentaDescripcion", transacciones.TranCuenta);
            return View(transacciones);
        }

        // GET: Transacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.TranTipo = new SelectList(db.TransaccionesTipos, "TranTiposId", "TranTiposDescripcion", transacciones.TranTipo);
            return View(transacciones);
        }

        // POST: Transacciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TranTipo = new SelectList(db.TransaccionesTipos, "TranTiposId", "TranTiposDescripcion", transacciones.TranTipo);
            return View(transacciones);
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
