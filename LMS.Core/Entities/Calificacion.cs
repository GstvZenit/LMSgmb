using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Calificacion : BaseEntity
    {
        //public long Id { get; set; }
        public DateTime? FechaCalificacion { get; set; }
        public decimal? Nota { get; set; }
        public long IdInscripcion { get; set; }
        public long IdActividad { get; set; }

        public virtual Actividad IdActividadNavigation { get; set; }
        public virtual Inscripcion IdInscripcionNavigation { get; set; }
    }
}
