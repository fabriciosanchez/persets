//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Persets.Backend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Logs
    {
        public string GUID { get; set; }
        public string UserGUID { get; set; }
        public string Operation { get; set; }
        public System.DateTime DateTimeOccurence { get; set; }
        public bool SuccessStatus { get; set; }
        public string PublicIP { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
