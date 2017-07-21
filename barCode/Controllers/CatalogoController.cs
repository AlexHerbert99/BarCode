using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using barCode.Models;
using System.Net;

namespace barCode.Controllers
{
    public class CatalogoController : Controller
    {

        barCodeEntities db = new barCodeEntities();


        // GET: Catalogo
        public ActionResult Index()
        {
            List<Producto> x = db.Producto.ToList();
            return View(x);
        }

        //public ActionResult mostrarDetalles(int id)
        //{
        //    Producto p = db.Producto.Find(id);
        //    return View(p);
        //}


        public ActionResult mostrarDetalles(int? id)
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
            return View("mostrarDetalles");
        }

    }
}