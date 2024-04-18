using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMIForAll.Models;

namespace CMIForAll.Controllers
{
    public class PerspectivasController : Controller
    {
        private CMIModelContainer db = new CMIModelContainer();

        // GET: Perspectivas
        public ActionResult Index()
        {
            return View(db.Perspectivas.ToList());
        }

        // GET: Perspectivas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perspectiva perspectiva = db.Perspectivas.Find(id);
            if (perspectiva == null)
            {
                return HttpNotFound();
            }
            return View(perspectiva);
        }

        // GET: Perspectivas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perspectivas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Perspectiva perspectiva)
        {
            if (ModelState.IsValid)
            {
                db.Perspectivas.Add(perspectiva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perspectiva);
        }

        // GET: Perspectivas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perspectiva perspectiva = db.Perspectivas.Find(id);
            if (perspectiva == null)
            {
                return HttpNotFound();
            }
            return View(perspectiva);
        }

        // POST: Perspectivas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Perspectiva perspectiva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perspectiva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perspectiva);
        }

        // GET: Perspectivas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perspectiva perspectiva = db.Perspectivas.Find(id);
            if (perspectiva == null)
            {
                return HttpNotFound();
            }
            return View(perspectiva);
        }

        // POST: Perspectivas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perspectiva perspectiva = db.Perspectivas.Find(id);
            db.Perspectivas.Remove(perspectiva);
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
