namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Presupuesto")]
    public partial class Presupuesto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Presupuesto()
        {
            PresupuestoItems = new HashSet<PresupuestoItems>();
        }

        public int PresupuestoId { get; set; }

        [Required]
        [StringLength(50)]
        public string PresupuestoDescripcion { get; set; }

        public decimal PresupuestoMonto { get; set; }

        public int? PresupuestoTipoMoneda { get; set; }

        public DateTime PresupuestoFhActualizacion { get; set; }

        public DateTime PresupuestoFhCreacion { get; set; }

        public virtual Monedas Monedas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PresupuestoItems> PresupuestoItems { get; set; }
    }
}
