using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using barCode.Models;

namespace barCode.Controllers
{
    public class BoletasController : Controller
    {
        private barCodePruebaEntities db = new barCodePruebaEntities();

        // GET: Boletas
        public ActionResult Index()
        {
            return View(db.Boleta.ToList());
        }

        // GET: Boletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleta boleta = db.Boleta.Find(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // GET: Boletas/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBoleta,IdRegistro,IdCliente,IdDistribuidor,NroBoleta,Total,Fecha,Despachado,Detalle")] Boleta boleta)
        {
            if (ModelState.IsValid)
            {
                db.Boleta.Add(boleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boleta);
        }

        // GET: Boletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleta boleta = db.Boleta.Find(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBoleta,IdRegistro,IdCliente,IdDistribuidor,NroBoleta,Total,Fecha,Despachado,Detalle")] Boleta boleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boleta);
        }

        // GET: Boletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boleta boleta = db.Boleta.Find(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // POST: Boletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Boleta boleta = db.Boleta.Find(id);
            db.Boleta.Remove(boleta);
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
