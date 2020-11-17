using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Core.DTO
{
    public class UsuarioDTO
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }
        public long? Tipo { get; set; }
        public long? IdRef { get; set; }
        public long IdRol { get; set; }
    }
}
