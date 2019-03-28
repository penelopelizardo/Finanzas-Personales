namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ingresos
    {
        [Key]
        public int IngresoId { get; set; }

        [Required]
        [StringLength(50)]
        public string IngresoDescripcion { get; set; }

        public decimal IngresoMonto { get; set; }

        public DateTime IngresoFecha { get; set; }

        public bool IngresoRecurrente { get; set; }

        public DateTime? IngresoRecurrenteFhLimite { get; set; }

        public int? IngresoTipo { get; set; }

        public int? IngresoCuenta { get; set; }

        [NotMapped]
        public string IngresoFh { get; set; }

        [NotMapped]
        public string IngresoFhLimite { get; set; }

        public virtual Cuentas Cuentas { get; set; }

        public virtual TiposIngresos TiposIngresos { get; set; }
    }
}
