using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ServicioWebApi.Interfaces;

namespace ServicioWebApi.Models
{
    public partial class Articulo: IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Unicode(false)]
        public string Nombre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Precio { get; set; }
        public int? Stock { get; set; }
    }
}
