namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Gastos
    {
        [Key]
        public int GastoId { get; set; }

        [Required]
        [StringLength(50)]
        public string GastoDescripcion { get; set; }

        public decimal GastoMonto { get; set; }

        public DateTime GastoFecha { get; set; }

        public bool GastoRecurrente { get; set; }

        public DateTime? GastoRecurrenteFhLimite { get; set; }

        public int? GastoTipo { get; set; }

        public int? GastoCuenta { get; set; }

        public virtual Cuentas Cuentas { get; set; }

        public virtual TiposIngresos TiposIngresos { get; set; }
    }
}
