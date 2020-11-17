using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.Core.DTO
{
    public class EstudianteDTO
    {
        public long Id { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
