using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("Receptors")]
    public class Receptor
    {
        public Receptor()
        {
            revenues = new HashSet<Revenue>();
        }
        [Key]
        [Column(TypeName = "VARCHAR")]
        [Required]
        [StringLength(15)]
        public string receptor_code { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(8)]
        public string issuer_code { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(8)]
        public string agent_code { get; set; }
        [Required]
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string first_name { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string last_name { get; set; }
        [StringLength(10)]
        [Column(TypeName = "VARCHAR")]
        public string other_name { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string company_name { get; set; }
        public DateTime dob { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(5)]
        public string gender { get; set; }
        [Column(TypeName = "VARCHAR")]
        public string receptor_type { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string addresse { get; set; }
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string city { get; set; }
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string state { get; set; }
        [StringLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string country { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string background { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string nature_of_business { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string area_of_business { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string company_size { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public virtual ICollection<Revenue> revenues { get; set; }

    }
}