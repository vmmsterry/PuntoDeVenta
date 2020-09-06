using PuntoDeVenta.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PuntoDeVenta.Controllers
{
    public class VentasController : Controller
    {
        private PuntoDeVentaEntities2 db = new PuntoDeVentaEntities2();

        // GET: Ventas
        public ActionResult Index()
        {
            return View(db.CLIENTES.ToList());
        }

        public JsonResult BuscaArticulos(string cadena)
        {
            int idArticulo;
            bool bandera = int.TryParse(cadena, out idArticulo);

            List<ARTICULOS> ltArticulos = new List<ARTICULOS>();
            if (bandera)
                ltArticulos = db.ARTICULOS.Where(a => a.CODIGO.Equals(cadena)).ToList();
            
            else
                ltArticulos = db.ARTICULOS.Where(a => a.DESCRIPCION.Equals(cadena)).ToList();
            
            return Json(new { lt = ltArticulos }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GuardaVenta(List<string> rows, string total, string tipoPago, int idCliente)
        {
            string msj = string.Empty;
            try
            {
                VENTAS objVenta = new VENTAS();
                objVenta.ID_CLIENTE = idCliente;
                objVenta.TIPO_PAGO = tipoPago;
                objVenta.MONTO = Convert.ToDecimal(total);
                objVenta.FECHA = DateTime.Now;
                db.VENTAS.Add(objVenta);
                db.SaveChanges();

                int idVenta = objVenta.ID;

                ARTICULOS_VENTA objArticulos = new ARTICULOS_VENTA();
                rows.ForEach(x =>
                {
                    var row = x.Split('-');
                    var id = row[0];
                    var precio = row[2];
                    objArticulos.ID_ARTICULO = Convert.ToInt32(id);
                    objArticulos.MONTO_ARTICULO = Convert.ToDecimal(precio);
                    objArticulos.ID_VENTA1 = idVenta;
                    db.ARTICULOS_VENTA.Add(objArticulos);
                    db.SaveChanges();
                });
            }
            catch(Exception ex)
            {
                msj = ex.Message;
            }

            return Json(new { msj }, JsonRequestBehavior.AllowGet);
        }
    }
}