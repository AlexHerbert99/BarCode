﻿using System;
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
    public class ProductosController : Controller
    {
        private barCodeEntities db = new barCodeEntities();

        public ActionResult Index()
        {
            return View(db.Producto.ToList());
        }

        ////GET: Productos
        //int prodXpag = 3; //Elementos por pagina
        //public ActionResult Index(int pagina = 1)
        //{
        //    decimal numPage = 0;
        //    decimal regTotales = db.Producto.Count();
        //    numPage = Math.Ceiling(regTotales / prodXpag);

        //    ViewBag.Total = numPage + 1;

        //    int salto = 0;
        //    salto = (pagina - 1) * prodXpag;

        //    var p = db.Producto.Include(x=> x.Categoria);
        //    return View(p.OrderBy(x => x.IdProducto).Skip(salto).Take(prodXpag).ToList());
        //}

        //BUSCADOR
        public ActionResult Buscador(string nombre)
        {
            var query = db.Producto.Where(x => x.NombreProd.Contains(nombre));
            return View("Index", query);
        }



        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }


        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,IdBoleta,IdCategoria,Foto,NombreProd,Marca,Stock,Precio,Descripcion,Eliminado")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,IdBoleta,IdCategoria,Foto,NombreProd,Marca,Stock,Precio,Descripcion,Eliminado")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
