using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Estudiante : BaseEntity
    {
        public Estudiante()
        {
            Inscripcion = new HashSet<Inscripcion>();
        }

        //public long Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public virtual ICollection<Inscripcion> Inscripcion { get; set; }
    }
}
