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

    }
}