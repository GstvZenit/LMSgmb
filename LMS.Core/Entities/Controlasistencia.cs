using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Controlasistencia : BaseEntity
    {
        //public long Id { get; set; }
        public DateTime? FechaAsistencia { get; set; }
        public string Asistio { get; set; }
        public long IdInscripcion { get; set; }

        public virtual Inscripcion IdInscripcionNavigation { get; set; }
    }
}
