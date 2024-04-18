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
    public class ObjetivoesController : Controller
    {
        private CMIModelContainer db = new CMIModelContainer();

        // GET: Objetivoes
        public ActionResult Index()
        {
            var objetivos = db.Objetivos.Include(o => o.CMI).Include(o => o.Perspectiva);
            return View(objetivos.ToList());
        }

        // GET: Objetivoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objetivo objetivo = db.Objetivos.Find(id);
            if (objetivo == null)
            {
                return HttpNotFound();
            }
            return View(objetivo);
        }

        // GET: Objetivoes/Create
        public ActionResult Create()
        {
            ViewBag.CMIId = new SelectList(db.CMISet, "Id", "Nombre");
            ViewBag.PerspectivaId = new SelectList(db.Perspectivas, "Id", "Nombre");
            return View();
        }

        // POST: Objetivoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Metrica,Ponderacion,CMIId,PerspectivaId")] Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                db.Objetivos.Add(objetivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CMIId = new SelectList(db.CMISet, "Id", "Nombre", objetivo.CMIId);
            ViewBag.PerspectivaId = new SelectList(db.Perspectivas, "Id", "Nombre", objetivo.PerspectivaId);
            return View(objetivo);
        }

        // GET: Objetivoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objetivo objetivo = db.Objetivos.Find(id);
            if (objetivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CMIId = new SelectList(db.CMISet, "Id", "Nombre", objetivo.CMIId);
            ViewBag.PerspectivaId = new SelectList(db.Perspectivas, "Id", "Nombre", objetivo.PerspectivaId);
            return View(objetivo);
        }

        // POST: Objetivoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Metrica,Ponderacion,CMIId,PerspectivaId")] Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objetivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CMIId = new SelectList(db.CMISet, "Id", "Nombre", objetivo.CMIId);
            ViewBag.PerspectivaId = new SelectList(db.Perspectivas, "Id", "Nombre", objetivo.PerspectivaId);
            return View(objetivo);
        }

        // GET: Objetivoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objetivo objetivo = db.Objetivos.Find(id);
            if (objetivo == null)
            {
                return HttpNotFound();
            }
            return View(objetivo);
        }

        // POST: Objetivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objetivo objetivo = db.Objetivos.Find(id);
            db.Objetivos.Remove(objetivo);
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
