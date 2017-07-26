using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using barCode.Models;

namespace barCode.Controllers
{
    public class LoginController : Controller
    {
        barCodeEntities db = new barCodeEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string user, string pass)
        {
            Models.Cliente us = db.Cliente.FirstOrDefault(x => x.Rut == user & x.Pass == pass);
            if (us != null)
            {
                var ticket = new FormsAuthenticationTicket(
                    1,
                    user, //Nombre Usuario
                    DateTime.Now, //Fecha creacion del ticket
                    DateTime.Now.AddMinutes(2),
                    false,
                    "admin;cliente" //User Data, cualquier cosa
                    );
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return Redirect("~/Catalogo/Index");
            }
            else
            {
                return Redirect("noEncontrado");
            }
        }

        public ActionResult noEncontrado()
        {
            return View();
        } 

        public ActionResult cerrarSesion()
        {
            FormsAuthentication.SignOut();
            return View("cerrarSesion");
        }

    }
}