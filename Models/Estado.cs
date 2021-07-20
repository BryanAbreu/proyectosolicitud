using System;
using System.Collections.Generic;

#nullable disable

namespace proyectosolicitud.Models
{
    public  class Estado
    {
        public Estado()
        {
            Solicituds = new List<Solicitud>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual List<Solicitud> Solicituds { get; set; }
    }
}
