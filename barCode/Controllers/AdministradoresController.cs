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
    public class AdministradoresController : Controller
    {
        private barCodeEntities db = new barCodeEntities();

        // GET: Administradores
        public ActionResult Index()
        {
            return View(db.Administradores.ToList());
        }

        // GET: Administradores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administradores administradores = db.Administradores.Find(id);
            if (administradores == null)
            {
                return HttpNotFound();
            }
            return View(administradores);
        }

        // GET: Administradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administradores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAdmin,IdDistribuidor,RutAdm,NombreAdm,ApPatAdm,ApMatAdm,Fono,Usuario,Contrasena")] Administradores administradores)
        {
            if (ModelState.IsValid)
            {
                db.Administradores.Add(administradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administradores);
        }

        // GET: Administradores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administradores administradores = db.Administradores.Find(id);
            if (administradores == null)
            {
                return HttpNotFound();
            }
            return View(administradores);
        }

        // POST: Administradores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAdmin,IdDistribuidor,RutAdm,NombreAdm,ApPatAdm,ApMatAdm,Fono,Usuario,Contrasena")] Administradores administradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administradores);
        }

        // GET: Administradores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administradores administradores = db.Administradores.Find(id);
            if (administradores == null)
            {
                return HttpNotFound();
            }
            return View(administradores);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administradores administradores = db.Administradores.Find(id);
            db.Administradores.Remove(administradores);
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
