using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Core.DTO
{
    public class InscripcionDTO
    {
        public long Id { get; set; }
        public string Estado { get; set; }
        public long IdCurso { get; set; }
        public long IdEstudiante { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
