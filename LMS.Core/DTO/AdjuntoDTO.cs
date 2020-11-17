using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Core.DTO
{
    public class AdjuntoDTO
    {
        public long Id { get; set; }
        public string Nombrearchivo { get; set; }
        public string Ubicacion { get; set; }
        public long IdRef { get; set; }
        public string Tipo { get; set; }
    }
}
