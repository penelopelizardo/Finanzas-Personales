namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PresupuestoItems
    {
        [Key]
        public int PItemId { get; set; }

        [Required]
        [StringLength(50)]
        public string PItemDescripcion { get; set; }

        public decimal PItemMonto { get; set; }

        public DateTime PItemFhActualizacion { get; set; }

        public int? PresupuestoId { get; set; }

        public virtual Presupuesto Presupuesto { get; set; }
    }
}
