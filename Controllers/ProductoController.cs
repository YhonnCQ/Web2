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

        public ActionResult ListarProductoXCategoria(string tipoBusqueda, string Buscar)
        {
            if (Buscar == null || Buscar == "")
            {
                return View(objProducto.ListarProductosPorCategoria());
            }
            else
            {
                switch (tipoBusqueda)
                {
                    case "CATEGORIA":
                        return View(objProducto.ListarProductosPorCategoria().Where(x => x.CategoriaNombre.Contains(Buscar)).ToList());
                    case "PRODUCTO":
                        return View(objProducto.ListarProductosPorCategoria().Where(x => x.Nombre.Contains(Buscar)).ToList());
                    case "STOCK":
                        return View(objProducto.ListarProductosPorCategoria().Where(x => x.Stock.ToString().Contains(Buscar)).ToList());
                    default:
                        return View(objProducto.ListarProductosPorCategoria());
                }
            }
        }

        public ActionResult BuscarProductoXCategoria(String Buscar)
        {

            return View();
        }

        public ActionResult ListarProductoXCategoriaCantidad(string Buscar)
        {
            return View(objProducto.ListarProductosPorCategoriaCantidad());
        }

    }
}