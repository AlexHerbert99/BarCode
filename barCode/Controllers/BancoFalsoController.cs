using barCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;

namespace barCode.Controllers
{
    public class BancoFalsoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        barCodePruebaEntities db = new barCodePruebaEntities();
        string urlbase = "http://www.devkairos.com/BancoFalsoportal/serviciosbancofalso/";
        string rut = "16243551-5";
        string clave = "123456";
        string apik = "3333333";

        // GET: BancoFalso
        public JsonResult LoginBco()
        {
            WebClient wc = new WebClient();
            NameValueCollection nv = new NameValueCollection();
            nv.Add("apikey", apik);
            nv.Add("user", rut);
            nv.Add("pass", clave);

            byte[] result = wc.UploadValues(urlbase + "Login", nv);
            string JsonLogin = Encoding.UTF8.GetString(result);
            RespuestaLogin r = JsonConvert.DeserializeObject<RespuestaLogin>(JsonLogin);
            return Json(r.estado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TraerCuentas()
        {
            WebClient wc = new WebClient();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("apikey", apik);
            nvc.Add("user", rut);
            nvc.Add("pass", clave);

            byte[] result = wc.UploadValues(urlbase + "TraerCuentas", nvc);
            string JsonResult = Encoding.UTF8.GetString(result);
            RespuestaCuentas rc = JsonConvert.DeserializeObject<RespuestaCuentas>(JsonResult);
            return Json(rc, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Pagar()
        {
            WebClient wc = new WebClient();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("apikey", apik);
            nvc.Add("user", rut);
            nvc.Add("pass", clave);
            nvc.Add("monto", "10000");
            nvc.Add("descripcion", "Resumen Carrito");
            nvc.Add("idPedido", "5005");
            nvc.Add("idCuenta", "7");

            byte[] result = wc.UploadValues(urlbase + "Pagar", nvc);
            string JsonResult = Encoding.UTF8.GetString(result);
            RespuestaPagos rp = JsonConvert.DeserializeObject<RespuestaPagos>(JsonResult);
            return Json(rp, JsonRequestBehavior.AllowGet);
        }
    }
}

        

       