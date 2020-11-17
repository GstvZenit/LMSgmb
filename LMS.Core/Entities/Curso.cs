using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Curso : BaseEntity
    {
        public Curso()
        {
            Inscripcion = new HashSet<Inscripcion>();
            Tema = new HashSet<Tema>();
        }

        //public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public long IdInstructor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Instructor IdInstructorNavigation { get; set; }
        public virtual ICollection<Inscripcion> Inscripcion { get; set; }
        public virtual ICollection<Tema> Tema { get; set; }
    }
}
