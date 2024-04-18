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
    public class CMIsController : Controller
    {
        private CMIModelContainer db = new CMIModelContainer();

        // GET: CMIs
        public ActionResult Index()
        {
            return View(db.CMISet.ToList());
        }

        // GET: CMIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMI cMI = db.CMISet.Find(id);
            if (cMI == null)
            {
                return HttpNotFound();
            }
            return View(cMI);
        }

        // GET: CMIs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CMIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Periodo")] CMI cMI)
        {
            if (ModelState.IsValid)
            {
                db.CMISet.Add(cMI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cMI);
        }

        // GET: CMIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMI cMI = db.CMISet.Find(id);
            if (cMI == null)
            {
                return HttpNotFound();
            }
            return View(cMI);
        }

        // POST: CMIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Periodo")] CMI cMI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cMI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cMI);
        }

        // GET: CMIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CMI cMI = db.CMISet.Find(id);
            if (cMI == null)
            {
                return HttpNotFound();
            }
            return View(cMI);
        }

        // POST: CMIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CMI cMI = db.CMISet.Find(id);
            db.CMISet.Remove(cMI);
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
