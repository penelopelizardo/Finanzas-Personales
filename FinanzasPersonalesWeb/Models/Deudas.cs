namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deudas
    {
        [Key]
        public int DeudaId { get; set; }

        [Required]
        [StringLength(50)]
        public string DeudaDescripcion { get; set; }

        public decimal DeudaMonto { get; set; }

        public int? DeudaTipoMoneda { get; set; }

        public bool DeudaEstado { get; set; }

        public DateTime DeudaFhCreacion { get; set; }

        public virtual Monedas Monedas { get; set; }
    }
}
