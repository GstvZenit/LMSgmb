using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Core.DTO
{
    public class ActividadDTO
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public long? Tipo { get; set; }
        public long IdTema { get; set; }
        public decimal? Ponderacion { get; set; }
    }
}
