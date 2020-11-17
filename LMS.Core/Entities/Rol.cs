using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Rol : BaseEntity
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        //public long Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
