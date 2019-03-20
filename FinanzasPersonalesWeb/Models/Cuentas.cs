namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cuentas
    {
        public Cuentas()
        {
            Gastos = new HashSet<Gastos>();
            Ingresos = new HashSet<Ingresos>();
        }

        [Key]
        public int CuentaId { get; set; }

        [Required]
        [StringLength(50)]
        public string CuentaDescripcion { get; set; }

        public decimal CuentaMontoInicio { get; set; }

        public int? CuentaTipoMoneda { get; set; }

        public DateTime CuentaFhCreacion { get; set; }

        public virtual Monedas Monedas { get; set; }

        public virtual ICollection<Gastos> Gastos { get; set; }

        public virtual ICollection<Ingresos> Ingresos { get; set; }

        public virtual ICollection<Transacciones> Transacciones { get; set; }
    }
}
