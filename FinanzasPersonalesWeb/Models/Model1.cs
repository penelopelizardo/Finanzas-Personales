namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=FinanzasPersonalesModel")
        {
        }

        public virtual DbSet<Cuentas> Cuentas { get; set; }
        public virtual DbSet<Deudas> Deudas { get; set; }
        public virtual DbSet<Gastos> Gastos { get; set; }
        public virtual DbSet<Ingresos> Ingresos { get; set; }
        public virtual DbSet<Monedas> Monedas { get; set; }
        public virtual DbSet<Presupuesto> Presupuesto { get; set; }
        public virtual DbSet<PresupuestoItems> PresupuestoItems { get; set; }
        public virtual DbSet<TiposGastos> TiposGastos { get; set; }
        public virtual DbSet<TiposIngresos> TiposIngresos { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuentas>()
                .Property(e => e.CuentaDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Cuentas>()
                .Property(e => e.CuentaMontoInicio)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Cuentas>()
                .HasMany(e => e.Gastos)
                .WithOptional(e => e.Cuentas)
                .HasForeignKey(e => e.GastoCuenta);

            modelBuilder.Entity<Cuentas>()
                .HasMany(e => e.Ingresos)
                .WithOptional(e => e.Cuentas)
                .HasForeignKey(e => e.IngresoCuenta);

            modelBuilder.Entity<Deudas>()
                .Property(e => e.DeudaDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Deudas>()
                .Property(e => e.DeudaMonto)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Gastos>()
                .Property(e => e.GastoDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Gastos>()
                .Property(e => e.GastoMonto)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Ingresos>()
                .Property(e => e.IngresoDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Ingresos>()
                .Property(e => e.IngresoMonto)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Monedas>()
                .Property(e => e.MonedaDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Monedas>()
                .Property(e => e.MonedaSimbolo)
                .IsUnicode(false);

            modelBuilder.Entity<Monedas>()
                .HasMany(e => e.Cuentas)
                .WithOptional(e => e.Monedas)
                .HasForeignKey(e => e.CuentaTipoMoneda);

            modelBuilder.Entity<Monedas>()
                .HasMany(e => e.Deudas)
                .WithOptional(e => e.Monedas)
                .HasForeignKey(e => e.DeudaTipoMoneda);

            modelBuilder.Entity<Monedas>()
                .HasMany(e => e.Presupuesto)
                .WithOptional(e => e.Monedas)
                .HasForeignKey(e => e.PresupuestoTipoMoneda);

            modelBuilder.Entity<Presupuesto>()
                .Property(e => e.PresupuestoDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Presupuesto>()
                .Property(e => e.PresupuestoMonto)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PresupuestoItems>()
                .Property(e => e.PItemDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PresupuestoItems>()
                .Property(e => e.PItemMonto)
                .HasPrecision(8, 2);

            modelBuilder.Entity<TiposGastos>()
                .Property(e => e.TiposGastosDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TiposIngresos>()
                .Property(e => e.TipoIngresoDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TiposIngresos>()
                .HasMany(e => e.Gastos)
                .WithOptional(e => e.TiposIngresos)
                .HasForeignKey(e => e.GastoTipo);

            modelBuilder.Entity<TiposIngresos>()
                .HasMany(e => e.Ingresos)
                .WithOptional(e => e.TiposIngresos)
                .HasForeignKey(e => e.IngresoTipo);
            modelBuilder.Entity<Transacciones>()
                .Property(e => e.TranDescripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.TranMonto)
                .HasPrecision(8, 2);

        }
    }
}
