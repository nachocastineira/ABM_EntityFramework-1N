using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABM_ProductoProveedor.Entidades;

namespace ABM_ProductoProveedor.Controllers
{
        public class ProductosController : Controller
        {

            BDProductoProveedorEntities bd = new BDProductoProveedorEntities();

            public ActionResult Nuevo()
            {
                ViewBag.proveedores = bd.Proveedor.ToList();

                return View();
            }

            [HttpPost]
            public ActionResult Nuevo(Producto p)  //Lo ideal es usar en Binding en el parametro, para pasarle solo lo que quiero
            {
                Producto prodNuevo = new Producto();

                prodNuevo.Nombre = p.Nombre;
                prodNuevo.IdProveedor = p.IdProveedor;

                bd.Producto.Add(prodNuevo);
                bd.SaveChanges();

                return RedirectToAction("Lista");
            }

            public ActionResult Lista()
            {
                List<Producto> productos = bd.Producto.ToList();
                ViewBag.productos = productos;

                return View(productos);
            }

            public ActionResult Modificar(int id)
            {
                Producto p = bd.Producto.FirstOrDefault(o => o.IdProducto == id);

                ViewBag.proveedores = bd.Proveedor.ToList();

                return View(p);
            }

            [HttpPost]
            public ActionResult Modificar(Producto p)
            {
                Producto prod = bd.Producto.FirstOrDefault(o => o.IdProducto == p.IdProducto);

                ViewBag.proveedores = bd.Proveedor.ToList();

                prod.Nombre = p.Nombre;
                prod.IdProveedor = p.IdProveedor;

                bd.SaveChanges();

                return RedirectToAction("Lista");
            }


        }
    }