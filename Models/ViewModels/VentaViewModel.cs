using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaestroDetalleMVC.Models.ViewModels
{
    public class VentaViewModel
    {
        //Aquí vamo a hechar los datos de nuestra base de datos
        public string Cliente { get; set; } //si no hacemos esto nuestro datos no iran a un variable
        public List<Concepto> conceptos { get; set; }
        // aqui traermos de la clase de concepto una lista de los datos
    }

    public class Concepto { 
        //clase concepto y los datos representativos que se traeran de la base de datos
        //pero a nivel de variables
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }

    }
}