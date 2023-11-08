using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ServicioWebApi.Interfaces;

namespace ServicioWebApi.Models
{
    public partial class publisher: IEntity
    {
        [NotMapped]
        public int ID { get; set; }
        [Key]
        [StringLength(4)]
        [Unicode(false)]
        public string? pub_id { get; set; }
        [StringLength(40)]
        [Unicode(false)]
        public string? pub_name { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? city { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? state { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? country { get; set; }
    }
}
