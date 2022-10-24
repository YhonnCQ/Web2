using System.Linq;

namespace Lab7_LINQ_BD_Condori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CATEGORIA")]
    public partial class CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIA()
        {
            PRODUCTOes = new HashSet<PRODUCTO>();
        }

        [Key]
        public int IDCATEGORIA { get; set; }

        [Required]
        [StringLength(50)]
        public string NOMBRE { get; set; }

        [Column(TypeName = "text")]
        public string DESCRIPCION { get; set; }

        [Required]
        [StringLength(1)]
        public string ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCTO> PRODUCTOes { get; set; }

        // Metodos de la clase Categoria

        public List<CATEGORIA> Listar()
        {
            var categorias = new List<CATEGORIA>();
            try
            {
                using (var db = new Model())
                {
                    categorias = db.CATEGORIAs.ToList();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return categorias;
        }

        public List<CATEGORIA> ListarConsulta()
        {
            var categorias = new List<CATEGORIA>();
            try
            {
                using (var db = new Model())
                {
                    categorias = db.CATEGORIAs.Where(x => x.NOMBRE.StartsWith("P")).ToList();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return categorias;
        }

    }
}
