//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace barCode.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Administradores
    {
        public int IdAdmin { get; set; }
        public Nullable<int> IdDistribuidor { get; set; }
        public string RutAdm { get; set; }
        public string NombreAdm { get; set; }
        public string ApPatAdm { get; set; }
        public string ApMatAdm { get; set; }
        public string Fono { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    
        public virtual Distribuidor Distribuidor { get; set; }
    }
}
