using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaestroDetalleMVC.Models.ViewModels
{
    public class VentaViewModel
    {
        public string Cliente { get; set; }
        public List<Concepto> conceptos { get; set; }
    }

    public class Concepto
    {
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
       
}