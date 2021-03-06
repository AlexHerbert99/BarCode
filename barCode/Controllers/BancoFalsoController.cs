﻿using barCode.Models;
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
        string urlbase = "http://www.devkairos.com/BancoFalsoportal/serviciosbancofalso/";
        string rut = "16243551-5";
        string clave = "123456";
        string apik = "3333333";
        List<Producto> carro = new List<Producto>();

        public ActionResult Index()
        {
            if (Session["carro"] == null)
            {
                Session["carro"] = carro;
            }
            else
            {
                carro = (List<Producto>)Session["carro"];
            }
            return View(carro);
        }     
        
       
        public JsonResult loginBanco(string user, string pass)
        {
            WebClient wc = new WebClient();
            NameValueCollection nv = new NameValueCollection();
            nv.Add("apikey", apik);
            nv.Add("user", user);
            nv.Add("pass", pass);

            byte[] result = wc.UploadValues(urlbase + "Login", nv);
            string JsonLogin = Encoding.UTF8.GetString(result);
            RespuestaLogin r = JsonConvert.DeserializeObject<RespuestaLogin>(JsonLogin);
            return Json(r.estado, JsonRequestBehavior.AllowGet);            
        }

        public JsonResult traerCuentas()
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

        public JsonResult Pagar(string monto, string cuenta)
        {
            WebClient wc = new WebClient();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("apikey", apik);            
            nvc.Add("monto", monto);
            nvc.Add("descripcion", "Compra en Barcode");
            nvc.Add("idPedido", "10");
            nvc.Add("idCuenta", cuenta);

            byte[] result = wc.UploadValues(urlbase + "Pagar", nvc);
            string JsonResult = Encoding.UTF8.GetString(result);
            RespuestaPagos rp = JsonConvert.DeserializeObject<RespuestaPagos>(JsonResult);
            return Json(rp, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult anularCompra(string monto, string descripcion, string idPedido, string idCuenta)
        {
            WebClient wc = new WebClient();
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("apikey", apik);
            nvc.Add("descripcion", descripcion);
            nvc.Add("idPedido", idPedido);
            nvc.Add("idCuenta", idCuenta);
            nvc.Add("monto", monto);

            byte[] result = wc.UploadValues(urlbase + "Anular", nvc);
            string JsonResult = Encoding.UTF8.GetString(result);
            RespuestaAnulacion ra = JsonConvert.DeserializeObject<RespuestaAnulacion>(JsonResult);
            return Json(ra, JsonRequestBehavior.AllowGet);
        }          

        public ActionResult PagoOk()
        {
            return View();
        }

        //public ActionResult seleccionarCuenta()
        //{
        //    var cuentas = new List<Seleccionar>();
        //    cuentas.Add(new Seleccionar()
        //    {
        //        id = 1,
        //        Nombre = "Cuenta Corriente",
        //        idCuenta = 154
        //    });
        //    cuentas.Add(new Seleccionar()
        //    {
        //        id = 2,
        //        Nombre = "Cuenta Vista",
        //        idCuenta = 155
        //    });

        //    var list = new SelectList(cuentas, "idCuenta");
        //    ViewData["cuentas"] = list;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult seleccionarCuenta(int cuenta)
        //{
        //    return View();
        //}

    }
}



