using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Actividad : BaseEntity
    {
        public Actividad()
        {
            Calificacion = new HashSet<Calificacion>();
        }

        //public long Id { get; set; }
        public string Descripcion { get; set; }
        public long? Tipo { get; set; }
        public long IdTema { get; set; }
        public decimal? Ponderacion { get; set; }

        public virtual Tema IdTemaNavigation { get; set; }
        public virtual ICollection<Calificacion> Calificacion { get; set; }
    }
}
