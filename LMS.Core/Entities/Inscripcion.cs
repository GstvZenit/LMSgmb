using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Inscripcion : BaseEntity
    {
        public Inscripcion()
        {
            Calificacion = new HashSet<Calificacion>();
            Controlasistencia = new HashSet<Controlasistencia>();
        }

        //public long Id { get; set; }
        public string Estado { get; set; }
        public long IdCurso { get; set; }
        public long IdEstudiante { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Estudiante IdEstudianteNavigation { get; set; }
        public virtual ICollection<Calificacion> Calificacion { get; set; }
        public virtual ICollection<Controlasistencia> Controlasistencia { get; set; }
    }
}
