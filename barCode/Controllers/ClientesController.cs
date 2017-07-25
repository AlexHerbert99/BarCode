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
    public class ClientesController : Controller
    {
        private barCodeEntities1 db = new barCodeEntities1();

        int itemXpag = 3;
        // GET: Clientes
        //public ActionResult Index()
        //{
        //    return View(db.Cliente.ToList());
        //}

        public ActionResult Index(int pagina = 1)
        {
            decimal count = db.Cliente.Count();
            decimal total = Math.Ceiling(count / itemXpag);

            ViewBag.Total = total + 1;
            int salto = (pagina - 1) * itemXpag;

            var cli = db.Cliente.OrderBy(x => x.Rut).Skip(salto).Take(itemXpag);
            return View(cli.ToList());
        }

        //BUSCADOR
        public ActionResult Buscador(string nombre)
        {
            var query = db.Cliente.Where(x => x.Nombres.Contains(nombre));
            decimal count = query.Count();
            decimal total = Math.Ceiling(count / itemXpag);
            return View("Index", query);
        }

        //LOGIN
        public ActionResult Validar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Validar(string user, string password)
        {
            Models.Cliente us = db.Cliente.FirstOrDefault(x => x.User == user & x.Pass == password);
            if (us != null)
            {
                return RedirectToAction("Index", "Catalogo");
            }
            else
            {
                return RedirectToAction("noEncontrado", "Clientes");
            }
        }

        public ActionResult noEncontrado()
        {
            ViewBag.Error = "No te haz registrado?";
            return View();
        }
        

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Rut,Nombres,ApPaterno,ApMaterno,Telefono,User,Pass")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Rut,Nombres,ApPaterno,ApMaterno,Telefono,User,Pass")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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
