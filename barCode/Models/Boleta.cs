//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace barCode.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Boleta
    {
        public int IdBoleta { get; set; }
        public int idMedioPago { get; set; }
        public int IdCliente { get; set; }
        public int IdDistribuidor { get; set; }
        public int NroBoleta { get; set; }
        public int Total { get; set; }
        public string Fecha { get; set; }
        public bool Despachado { get; set; }
        public string Detalle { get; set; }
        public int idDetalle { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Distribuidor Distribuidor { get; set; }
        public virtual Cuentas Cuentas { get; set; }
        public virtual Detalle Detalle1 { get; set; }
    }
}
