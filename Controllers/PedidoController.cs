using Lab7_LINQ_BD_Condori.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab7_LINQ_BD_Condori.Controllers
{
    public class PedidoController : Controller
    {
        private PEDIDO objPedido = new PEDIDO();
        // GET: Pedido
        public ActionResult Index()
        {
            return View(objPedido.ListarMontoTotalPorPedido());
        }
    }
}