using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab7_LINQ_BD_Condori.Models;

namespace Lab7_LINQ_BD_Condori.Controllers
{
    public class CategoriaController : Controller
    {
        private CATEGORIA objCategoria = new CATEGORIA();

        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            return View(objCategoria.Listar());
        }

        public ActionResult ListarConsulta()
        {
            return View(objCategoria.ListarConsulta());
        }
    }
}