using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClienteRazor.Models
{
    public class publisher
    {
        [Key]
        [StringLength(4)]
        [DisplayName("Id")]
        public string? pub_id { get; set; }
        [StringLength(40)]
        [DisplayName("Nombre")]
        public string? pub_name { get; set; }
        [StringLength(20)]
        [DisplayName("Ciudad")]
        public string? city { get; set; }
        [StringLength(30)]
        [DisplayName("Estado")]
        public string? state { get; set; }
        [StringLength(30)]
        [DisplayName("Pais")]
        public string? country { get; set; }
    }
}
