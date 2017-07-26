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

        int artXpag = 3;
        // GET: Catalogo
        public ActionResult Index(int pagina = 1)
        {
            List<Producto> x = db.Producto.ToList();

            decimal count = db.Producto.Count();
            decimal total = Math.Ceiling(count / artXpag);

            ViewBag.Total = total + 1;
            int salto = (pagina - 1) * artXpag;

            var pro = db.Producto.OrderBy(z=> z.IdProducto).Skip(salto).Take(artXpag);

            return View(pro.ToList());
        }

        public ActionResult Buscar(string Nombre)

        {
            var Pilsen = db.Producto.Where(x => x.NombreProd.Contains(Nombre));
            return View("Catalogo", Pilsen);
        }

    }
}