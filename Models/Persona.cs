using System;
using System.Collections.Generic;

#nullable disable

namespace proyectosolicitud.Models
{
    public  class Persona
    {
        public Persona()
        {
            Solicituds = new List<Solicitud>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimieto { get; set; }
        public int? Pasaporte { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }

        public virtual List<Solicitud> Solicituds { get; set; }
    }
}
