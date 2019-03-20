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
    public class TiposIngresosController : Controller
    {
        private Model1 db = new Model1();

        // GET: TiposIngresos
        public ActionResult Index()
        {
            return View(db.TiposIngresos.ToList());
        }

        // GET: TiposIngresos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposIngresos tiposIngresos = db.TiposIngresos.Find(id);
            if (tiposIngresos == null)
            {
                return HttpNotFound();
            }
            return View(tiposIngresos);
        }

        // GET: TiposIngresos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposIngresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoIngresoId,TipoIngresoDescripcion")] TiposIngresos tiposIngresos)
        {
            if (ModelState.IsValid)
            {
                db.TiposIngresos.Add(tiposIngresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposIngresos);
        }

        // GET: TiposIngresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposIngresos tiposIngresos = db.TiposIngresos.Find(id);
            if (tiposIngresos == null)
            {
                return HttpNotFound();
            }
            return View(tiposIngresos);
        }

        // POST: TiposIngresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoIngresoId,TipoIngresoDescripcion")] TiposIngresos tiposIngresos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposIngresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposIngresos);
        }

        // GET: TiposIngresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposIngresos tiposIngresos = db.TiposIngresos.Find(id);
            if (tiposIngresos == null)
            {
                return HttpNotFound();
            }
            return View(tiposIngresos);
        }

        // POST: TiposIngresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TiposIngresos tiposIngresos = db.TiposIngresos.Find(id);
            db.TiposIngresos.Remove(tiposIngresos);
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
