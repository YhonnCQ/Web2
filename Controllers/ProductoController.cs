using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab7_LINQ_BD_Condori.Models;

namespace Lab7_LINQ_BD_Condori.Controllers
{
    public class ProductoController : Controller
    {
        private PRODUCTO objProducto = new PRODUCTO();
        private CATEGORIA objCategoria = new CATEGORIA();

        // GET: Producto
        public ActionResult Index()
        {
            return View(objProducto.ListarProductos());
        }

        public ActionResult ListarProductoXCategoria()
        {
            return View(objProducto.ListarProductosPorCategoria());
        }

        public ActionResult BuscarProductoXCategoria(String Buscar)
        {
            if (Buscar == null || Buscar == "")
            {
                return View(objProducto.ListarProductosPorCategoria());
            }
            else
            {
                return View(objProducto.BuscarProductosPorCategoria(Buscar));
            }
        }

        public ActionResult ListarProductoXCategoriaCantidad()
        {
            return View(objProducto.ListarProductosPorCategoriaCantidad());
        }
    }
}