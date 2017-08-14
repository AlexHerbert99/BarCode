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

        barCodePruebaEntities db = new barCodePruebaEntities();
        string urlbase = "http://www.devkairos.com/BancoFalsoportal/serviciobancofalso/";
        // GET: BancoFalso
        public JsonResult LoginBco()
        {
            WebClient wc = new WebClient();
            NameValueCollection nv = new NameValueCollection();
            nv.Add("apikey", "3333333");
            nv.Add("user", "16243551-5");
            nv.Add("pass", "123456");

            byte[] result = wc.UploadValues(urlbase + "Login", nv);
            string JsonLogin = Encoding.UTF8.GetString(result);
            RespuestaLogin r = JsonConvert.DeserializeObject<RespuestaLogin>(JsonLogin);
            return Json(r.estado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TraerCuentasBcoFalso(string user, string pass)
        {
            WebClient wc = new WebClient();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("apikey", "3333333");
            nvc.Add("user", user);
            nvc.Add("pass", pass);

            byte[] result = wc.UploadValues(urlbase + "TraerCuentas", nvc);
            string JsonResult = Encoding.UTF8.GetString(result);
            RespuestaCuentas rc = JsonConvert.DeserializeObject<RespuestaCuentas>(JsonResult);
            return Json(rc, JsonRequestBehavior.AllowGet);
        }
    }
}

        

       