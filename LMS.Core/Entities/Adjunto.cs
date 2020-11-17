using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Adjunto : BaseEntity
    {
        //public long Id { get; set; }
        public string Nombrearchivo { get; set; }
        public string Ubicacion { get; set; }
        public long IdRef { get; set; }
        public string Tipo { get; set; }
    }
}
