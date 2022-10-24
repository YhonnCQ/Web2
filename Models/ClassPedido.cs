using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7_LINQ_BD_Condori.Models
{
    public class ClassPedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string fecha { get; set; }
        public int monto { get; set; }
    }
}