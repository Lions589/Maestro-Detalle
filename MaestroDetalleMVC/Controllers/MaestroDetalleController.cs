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
        // GET: MaestroDetalle
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(VentaViewModel model) 
        {
            try
            {
                using (MaestroDetalleMVCEntities2 db = new MaestroDetalleMVCEntities2() )
                {
                    venta oVenta = new venta();
                    oVenta.fecha= DateTime.Now;
                    oVenta.cliente=model.Cliente;
                    db.venta.Add(oVenta);
                    db.SaveChanges();

                    foreach (var oC in model.conceptos)
                    {
                        concepto oConcepto = new concepto();
                        oConcepto.cantidad = oC.Cantidad;
                        oConcepto.nombre = oC.Nombre;
                        oConcepto.precioUnitario = oC.PrecioUnitario;
                        oConcepto.total = oC.Cantidad * oC.PrecioUnitario;
                        oConcepto.idVenta = oVenta.id;
                        db.concepto.Add(oConcepto);

                    }
                    

                    db.SaveChanges();
                }
                ViewBag.Message = "Registro Ingresado";
                return View();
            }
            catch (Exception ex) 
            {
                return View(model);
            }
        
        
        }
    }

}