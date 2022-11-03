using System.Linq;
using System.Linq.Expressions;

namespace Lab7_LINQ_BD_Condori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
        }

        [Key]
        public int IDPRODUCTO { get; set; }

        public int IDCATEGORIA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Column(TypeName = "text")]
        public string DESCRIPCION { get; set; }

        public int PRECIO { get; set; }

        public int STOCK { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }

        public List<PRODUCTO> ListarProductos()
        {
            var productos = new List<PRODUCTO>();
            try
            {
                using (var db = new Model())
                {
                    productos = db.PRODUCTOes.Where(x => x.NOMBRE.StartsWith("J") && x.PRECIO < 200).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return productos;
        }
        public List<ProductoViewModel> ListarProductosPorCategoria()
        {
            var productos = new List<ProductoViewModel>();
            try
            {
                using (var db = new Model())
                {
                    productos = db.PRODUCTOes.Include("CATEGORIA").Select(
                        x => new ProductoViewModel()
                        {
                            Id = x.IDPRODUCTO,
                            CategoriaNombre = x.CATEGORIA.NOMBRE,
                            Nombre = x.NOMBRE,
                            Precio = x.PRECIO,
                            Stock = x.STOCK,
                            Estado = x.STOCK == 0 ? "AGOTADO" : x.STOCK <= 10 ? "POR AGOTARSE" : "DISPONIBLE"
                        }).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return productos;
        }

        public List<ProductoViewModel> BuscarProductosPorCategoria(string Buscar)
        {
            var productos = new List<ProductoViewModel>();
            try
            {
                using (var db = new Model())
                {
                    productos = db.PRODUCTOes.Include("CATEGORIA").Where(x => x.CATEGORIA.NOMBRE.Contains(Buscar) ).Select(
                        x => new ProductoViewModel()
                        {
                            Id = x.IDPRODUCTO,
                            CategoriaNombre = x.CATEGORIA.NOMBRE,
                            Nombre = x.NOMBRE,
                            Precio = x.PRECIO,
                            Stock = x.STOCK,
                            Estado = x.STOCK == 0 ? "AGOTADO" : x.STOCK <= 10 ? "POR AGOTARSE" : "DISPONIBLE"
                        }).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return productos;
        }

        // Listar cantidad de productos por categoria
        public List<ClassProducto> ListarProductosPorCategoriaCantidad()
        {
            var productos = new List<ClassProducto>();
            try
            {
                using (var db = new Model())
                {
                    productos = db.PRODUCTOes.Include("CATEGORIA").GroupBy(x => x.CATEGORIA.IDCATEGORIA).Select(x => new ClassProducto()
                    {
                        Id = x.Key,
                        Nombre = x.FirstOrDefault().CATEGORIA.NOMBRE,
                        Cantidad = x.Count(),
                        Porcentaje = (double) x.Count() * 100 / db.PRODUCTOes.Count(),
                        Total = db.PRODUCTOes.Count()
                    }).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return productos;
        }


    }
}
