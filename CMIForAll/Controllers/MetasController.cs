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
    public class MetasController : Controller
    {
        private CMIModelContainer db = new CMIModelContainer();

        // GET: Metas
        public ActionResult Index()
        {
            var metas = db.Metas.Include(m => m.Indicador);
            return View(metas.ToList());
        }

        // GET: Metas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meta meta = db.Metas.Find(id);
            if (meta == null)
            {
                return HttpNotFound();
            }
            return View(meta);
        }

        // GET: Metas/Create
        public ActionResult Create()
        {
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "Id", "Nombre");
            return View();
        }

        // POST: Metas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,Valor_esperado,Fecha_limite,IndicadorId")] Meta meta)
        {
            if (ModelState.IsValid)
            {
                db.Metas.Add(meta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IndicadorId = new SelectList(db.Indicadores, "Id", "Nombre", meta.IndicadorId);
            return View(meta);
        }

        // GET: Metas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meta meta = db.Metas.Find(id);
            if (meta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "Id", "Nombre", meta.IndicadorId);
            return View(meta);
        }

        // POST: Metas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,Valor_esperado,Fecha_limite,IndicadorId")] Meta meta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "Id", "Nombre", meta.IndicadorId);
            return View(meta);
        }

        // GET: Metas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meta meta = db.Metas.Find(id);
            if (meta == null)
            {
                return HttpNotFound();
            }
            return View(meta);
        }

        // POST: Metas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meta meta = db.Metas.Find(id);
            db.Metas.Remove(meta);
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
