using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab7_LINQ_BD_Condori.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelSistema")
        {
        }

        public virtual DbSet<CATEGORIA> CATEGORIAs { get; set; }
        public virtual DbSet<CLIENTE> CLIENTEs { get; set; }
        public virtual DbSet<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }
        public virtual DbSet<EMPLEADO> EMPLEADOes { get; set; }
        public virtual DbSet<PEDIDO> PEDIDOes { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTOes { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<CATEGORIA>()
                .HasMany(e => e.PRODUCTOes)
                .WithRequired(e => e.CATEGORIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.IDCLIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<CLIENTE>()
                .HasMany(e => e.PEDIDOes)
                .WithRequired(e => e.CLIENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.APELLIDO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.CELULAR)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.DIRECCION)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLEADO>()
                .HasMany(e => e.USUARIOs)
                .WithRequired(e => e.EMPLEADO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PEDIDO>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<PEDIDO>()
                .Property(e => e.IDCLIENTE)
                .IsUnicode(false);

            modelBuilder.Entity<PEDIDO>()
                .HasMany(e => e.DETALLE_PEDIDO)
                .WithRequired(e => e.PEDIDO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.ESTADO)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .HasMany(e => e.DETALLE_PEDIDO)
                .WithRequired(e => e.PRODUCTO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.CLAVE)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.NIVEL)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.AVATAR)
                .IsUnicode(false);
        }
    }
}
