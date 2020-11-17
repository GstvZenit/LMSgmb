using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Core.DTO
{
    public class CursoDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public long IdInstructor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}
