using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Instructor :BaseEntity
    {
        public Instructor()
        {
            Curso = new HashSet<Curso>();
        }

        //public long Id { get; set; }
        public string NombresApellidos { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}
