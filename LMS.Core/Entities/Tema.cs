using System;
using System.Collections.Generic;
using LMS.Core.Entities;
namespace LMS.Core.Entities
{
    public partial class Tema : BaseEntity
    {
        public Tema()
        {
            Actividad = new HashSet<Actividad>();
        }

        //public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public long IdCurso { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public decimal? Ponderacion { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
    }
}
