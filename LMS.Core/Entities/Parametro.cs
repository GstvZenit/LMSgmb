using System;
using System.Collections.Generic;

namespace LMS.Core.Entities
{
    public partial class Parametro :BaseEntity
    {
        //public long Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
    }
}
