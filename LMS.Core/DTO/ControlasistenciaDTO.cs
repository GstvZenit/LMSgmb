using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Core.DTO
{
    public class ControlasistenciaDTO
    {
        public long Id { get; set; }
        public DateTime? FechaAsistencia { get; set; }
        public string Asistio { get; set; }
        public long IdInscripcion { get; set; }
    }
}
