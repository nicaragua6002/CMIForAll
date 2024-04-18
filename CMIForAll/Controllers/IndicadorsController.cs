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
    public class IndicadorsController : Controller
    {
        private CMIModelContainer db = new CMIModelContainer();

        // GET: Indicadors
        public ActionResult Index()
        {
            var indicadores = db.Indicadores.Include(i => i.Objetivo).Include(i => i.Tipo);
            return View(indicadores.ToList());
        }

        // GET: Indicadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador indicador = db.Indicadores.Find(id);
            if (indicador == null)
            {
                return HttpNotFound();
            }
            return View(indicador);
        }

        // GET: Indicadors/Create
        public ActionResult Create()
        {
            ViewBag.ObjetivoId = new SelectList(db.Objetivos, "Id", "Descripcion");
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Id");
            return View();
        }

        // POST: Indicadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Frecuencia_Medicion,Unidad_Medida,ObjetivoId,TipoId")] Indicador indicador)
        {
            if (ModelState.IsValid)
            {
                db.Indicadores.Add(indicador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObjetivoId = new SelectList(db.Objetivos, "Id", "Descripcion", indicador.ObjetivoId);
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Id", indicador.TipoId);
            return View(indicador);
        }

        // GET: Indicadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador indicador = db.Indicadores.Find(id);
            if (indicador == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObjetivoId = new SelectList(db.Objetivos, "Id", "Descripcion", indicador.ObjetivoId);
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Id", indicador.TipoId);
            return View(indicador);
        }

        // POST: Indicadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Frecuencia_Medicion,Unidad_Medida,ObjetivoId,TipoId")] Indicador indicador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(indicador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObjetivoId = new SelectList(db.Objetivos, "Id", "Descripcion", indicador.ObjetivoId);
            ViewBag.TipoId = new SelectList(db.Tipos, "Id", "Id", indicador.TipoId);
            return View(indicador);
        }

        // GET: Indicadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Indicador indicador = db.Indicadores.Find(id);
            if (indicador == null)
            {
                return HttpNotFound();
            }
            return View(indicador);
        }

        // POST: Indicadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Indicador indicador = db.Indicadores.Find(id);
            db.Indicadores.Remove(indicador);
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
