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
    public class PresupuestoItemsController : Controller
    {
        private Model1 db = new Model1();

        // GET: PresupuestoItems
        public ActionResult Index()
        {
            var presupuestoItems = db.PresupuestoItems.Include(p => p.Presupuesto);
            return View(presupuestoItems.ToList());
        }

        // GET: PresupuestoItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresupuestoItems presupuestoItems = db.PresupuestoItems.Find(id);
            if (presupuestoItems == null)
            {
                return HttpNotFound();
            }
            return View(presupuestoItems);
        }

        // GET: PresupuestoItems/Create
        public ActionResult Create()
        {
            ViewBag.PresupuestoId = new SelectList(db.Presupuesto, "PresupuestoId", "PresupuestoDescripcion");
            return View();
        }

        // POST: PresupuestoItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PItemId,PItemDescripcion,PItemMonto,PItemFhActualizacion,PresupuestoId")] PresupuestoItems presupuestoItems)
        {
            if (ModelState.IsValid)
            {
                db.PresupuestoItems.Add(presupuestoItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PresupuestoId = new SelectList(db.Presupuesto, "PresupuestoId", "PresupuestoDescripcion", presupuestoItems.PresupuestoId);
            return View(presupuestoItems);
        }

        // GET: PresupuestoItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresupuestoItems presupuestoItems = db.PresupuestoItems.Find(id);
            if (presupuestoItems == null)
            {
                return HttpNotFound();
            }
            ViewBag.PresupuestoId = new SelectList(db.Presupuesto, "PresupuestoId", "PresupuestoDescripcion", presupuestoItems.PresupuestoId);
            return View(presupuestoItems);
        }

        // POST: PresupuestoItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PItemId,PItemDescripcion,PItemMonto,PItemFhActualizacion,PresupuestoId")] PresupuestoItems presupuestoItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(presupuestoItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PresupuestoId = new SelectList(db.Presupuesto, "PresupuestoId", "PresupuestoDescripcion", presupuestoItems.PresupuestoId);
            return View(presupuestoItems);
        }

        // GET: PresupuestoItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresupuestoItems presupuestoItems = db.PresupuestoItems.Find(id);
            if (presupuestoItems == null)
            {
                return HttpNotFound();
            }
            return View(presupuestoItems);
        }

        // POST: PresupuestoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PresupuestoItems presupuestoItems = db.PresupuestoItems.Find(id);
            db.PresupuestoItems.Remove(presupuestoItems);
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
