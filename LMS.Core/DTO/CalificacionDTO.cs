using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Core.DTO
{
    public class CalificacionDTO
    {
        public long Id { get; set; }
        public DateTime? FechaCalificacion { get; set; }
        public decimal? Nota { get; set; }
        public long IdInscripcion { get; set; }
        public long IdActividad { get; set; }
    }
}
