using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7_LINQ_BD_Condori.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string CategoriaNombre { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }
}