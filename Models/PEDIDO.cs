using System.Linq;

namespace Lab7_LINQ_BD_Condori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PEDIDO")]
    public partial class PEDIDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PEDIDO()
        {
            DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
        }

        [Key]
        public int IDPEDIDO { get; set; }

        public DateTime FECHA { get; set; }

        [Required]
        [StringLength(20)]
        public string ESTADO { get; set; }

        [Required]
        [StringLength(20)]
        public string IDCLIENTE { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }

        // listar monto total por pedido
        public List<ClassPedido> ListarMontoTotalPorPedido()
        {
            var pedidosView = new List<ClassPedido>();
            try
            {
                using (var db = new Model())
                {
                    var pedidos = db.PEDIDOes.ToList();
                    foreach (var pedido in pedidos)
                    {
                        pedidosView.Add(db.DETALLE_PEDIDO.Where(x => x.IDPEDIDO == pedido.IDPEDIDO).Select(x => new ClassPedido
                        {
                            Id = x.IDPEDIDO,
                            Cliente = x.PEDIDO.CLIENTE.NOMBRE,
                            fecha = x.PEDIDO.FECHA.ToString(),
                            monto = (int)x.PEDIDO.DETALLE_PEDIDO.Sum(y => y.PRECIO * y.CANTIDAD)
                        }).First());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return pedidosView;
        }
    }
}
