using System;
using System.Collections.Generic;
using LMS.Core.Entities;
namespace LMS.Core.Entities
{
    public partial class Usuario: BaseEntity
    {
        //public long Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }
        public long? Tipo { get; set; }
        public long? IdRef { get; set; }
        public long IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
    }
}
