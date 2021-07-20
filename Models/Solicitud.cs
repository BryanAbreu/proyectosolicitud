using System;
using System.Collections.Generic;

#nullable disable

namespace proyectosolicitud.Models
{
    public  class Solicitud
    {
        public int Id { get; set; }
        public int? PersonaId { get; set; }
        public int? EstadoId { get; set; }
        public DateTime? FecahrCrea { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
