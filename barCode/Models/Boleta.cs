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
        public int IdRegistro { get; set; }
        public int IdCliente { get; set; }
        public Nullable<int> IdDistribuidor { get; set; }
        public Nullable<int> NroBoleta { get; set; }
        public Nullable<int> Total { get; set; }
        public string Fecha { get; set; }
        public Nullable<bool> Despachado { get; set; }
        public string Detalle { get; set; }
    }
}
