namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TransaccionesTipos
    {
        public TransaccionesTipos()
        {
            Transacciones = new HashSet<Transacciones>();
        }

        [Key]
        public int TranTiposId { get; set; }

        [Required]
        [StringLength(50)]
        public string TranTiposDescripcion { get; set; }

        public virtual ICollection<Transacciones> Transacciones { get; set; }
    }
}
