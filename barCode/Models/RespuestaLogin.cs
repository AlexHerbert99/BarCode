using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace barCode.Models
{
    public class RespuestaLogin
    {
        public string mensaje;
        public bool estado;
        public string observacion;
    }

    public class RespuestaCuentas
    {
        public string mensaje;
        public List<Cuentas> cuentas;
    }

}