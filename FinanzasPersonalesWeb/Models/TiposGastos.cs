namespace FinanzasPersonalesWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TiposGastos
    {
        public int TiposGastosId { get; set; }

        [Required]
        [StringLength(50)]
        public string TiposGastosDescripcion { get; set; }
    }
}
