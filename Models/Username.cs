//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alkemy_School.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Username
    {
        public int Docket { get; set; }
        public byte Access { get; set; }
        public bool Active { get; set; }
        public int DNI { get; set; }
    
        public virtual Person Person { get; set; }
    }
}
