using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaestroDetalleMVC.Models.ViewModels;
using MaestroDetalleMVC.Models;

namespace MaestroDetalleMVC.Controllers
{
    public class MaestroDetalleController : Controller
    {
        // GET: MaestroDetalle // Entra por GET cuando no se especifica como el Metoo Add()
        // Cuando mandamos datos por GET , se reciben en el navegador , escriber la URL y eso es un GET
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]  //El metodo Add Accedera por medio de HttPost //
        //POST ---> se usa para formulario porque vamos a recibir datos para el formulario
        public ActionResult Add(VentaViewModel model)
        {
            try
            {
                using (var db = new MaestroDetalleMVCEntities()) //aqui hemos creado la conexion a la base de datos
                {
                    Venta venta = new Venta();
                    venta.fecha = DateTime.Now; //esto es lo que recibe tu cliente la hora exacta del envio al servidor
                    venta.cliente = model.Cliente; //Hicimos Macth
                    db.Venta.Add(venta); // equivale a hacer el INSERT INTO
                    db.SaveChanges(); //hace cambios en la base de datos y crea su Autonumerico

                    foreach (var oC in model.conceptos)
                    {
                        var oConcepto = new Models.Concepto();
                        oConcepto.cantidad = oC.Cantidad;
                        oConcepto.nombre = oC.Nombre;
                        oConcepto.precioUnitario = oC.PrecioUnitario;
                        oConcepto.total = oC.Cantidad * oC.PrecioUnitario;
                        oConcepto.idVenta = venta.id; //una vez generado el autonumerico de arriba se igual al idventa
                        db.Concepto.Add(oConcepto);
                    }

                    db.SaveChanges(); //guarda los cambios

                }
                ViewBag.Message = "Usuario Insertado";
                return View();
            }
            catch (Exception ex)
            {

                return View();
            }
        }

    }
}