namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transacciones
    {
        [Key]
        public int TranId { get; set; }

        [Required]
        [StringLength(50)]
        public string TranDescripcion { get; set; }

        public decimal TranMonto { get; set; }

        public DateTime TranFecha { get; set; }

        public bool TranRecurrente { get; set; }

        public DateTime? TranRecurrenteFhLimite { get; set; }

        public int? TranTipo { get; set; }

        [ForeignKey("Cuentas")]
        public int? TranCuenta { get; set; }

        public virtual Cuentas Cuentas { get; set; }
    }
}
