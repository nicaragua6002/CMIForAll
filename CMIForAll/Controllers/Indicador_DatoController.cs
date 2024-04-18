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
    public class Indicador_DatoController : Controller
    {
        private CMIModelContainer db = new CMIModelContainer();

        // GET: Indicador_Dato
        public ActionResult Index()
        {
            var indicador_Datos = db.Indicador_Datos.Include(i => i.Indicador);
            return View(indicador_Datos.ToList());
        }

        // GET: Indicador_Dato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador_Dato indicador_Dato = db.Indicador_Datos.Find(id);
            if (indicador_Dato == null)
            {
                return HttpNotFound();
            }
            return View(indicador_Dato);
        }

        // GET: Indicador_Dato/Create
        public ActionResult Create()
        {
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "Id", "Nombre");
            return View();
        }

        // POST: Indicador_Dato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,Fecha,IndicadorId")] Indicador_Dato indicador_Dato)
        {
            if (ModelState.IsValid)
            {
                db.Indicador_Datos.Add(indicador_Dato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IndicadorId = new SelectList(db.Indicadores, "Id", "Nombre", indicador_Dato.IndicadorId);
            return View(indicador_Dato);
        }

        // GET: Indicador_Dato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador_Dato indicador_Dato = db.Indicador_Datos.Find(id);
            if (indicador_Dato == null)
            {
                return HttpNotFound();
            }
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "Id", "Nombre", indicador_Dato.IndicadorId);
            return View(indicador_Dato);
        }

        // POST: Indicador_Dato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,Fecha,IndicadorId")] Indicador_Dato indicador_Dato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicador_Dato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IndicadorId = new SelectList(db.Indicadores, "Id", "Nombre", indicador_Dato.IndicadorId);
            return View(indicador_Dato);
        }

        // GET: Indicador_Dato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador_Dato indicador_Dato = db.Indicador_Datos.Find(id);
            if (indicador_Dato == null)
            {
                return HttpNotFound();
            }
            return View(indicador_Dato);
        }

        // POST: Indicador_Dato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indicador_Dato indicador_Dato = db.Indicador_Datos.Find(id);
            db.Indicador_Datos.Remove(indicador_Dato);
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
