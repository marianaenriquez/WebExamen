using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ventasWeb.Models
{
    public class Ventas
    {
        public int IDVentas { get; set; }
        public int IDProductos { get; set; }
        public int CantidadVendida { get; set; }
        public string Fecha { get; set; }
    }
}
