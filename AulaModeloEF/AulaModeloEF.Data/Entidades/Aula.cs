using System;
using System.Collections.Generic;

namespace AulaModeloEF.Data.Entidades
{
    public partial class Aula
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? CantidadAlumnos { get; set; }
    }
}
