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
    public class TransaccionesTiposController : Controller
    {
        private Model1 db = new Model1();

        // GET: TransaccionesTipos
        public ActionResult Index()
        {
            return View(db.TransaccionesTipos.ToList());
        }

        // GET: TransaccionesTipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransaccionesTipos transaccionesTipos = db.TransaccionesTipos.Find(id);
            if (transaccionesTipos == null)
            {
                return HttpNotFound();
            }
            return View(transaccionesTipos);
        }

        // GET: TransaccionesTipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransaccionesTipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TranTiposId,TranTiposDescripcion")] TransaccionesTipos transaccionesTipos)
        {
            if (ModelState.IsValid)
            {
                db.TransaccionesTipos.Add(transaccionesTipos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transaccionesTipos);
        }

        // GET: TransaccionesTipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransaccionesTipos transaccionesTipos = db.TransaccionesTipos.Find(id);
            if (transaccionesTipos == null)
            {
                return HttpNotFound();
            }
            return View(transaccionesTipos);
        }

        // POST: TransaccionesTipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TranTiposId,TranTiposDescripcion")] TransaccionesTipos transaccionesTipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccionesTipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transaccionesTipos);
        }

        // GET: TransaccionesTipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransaccionesTipos transaccionesTipos = db.TransaccionesTipos.Find(id);
            if (transaccionesTipos == null)
            {
                return HttpNotFound();
            }
            return View(transaccionesTipos);
        }

        // POST: TransaccionesTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransaccionesTipos transaccionesTipos = db.TransaccionesTipos.Find(id);
            db.TransaccionesTipos.Remove(transaccionesTipos);
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
