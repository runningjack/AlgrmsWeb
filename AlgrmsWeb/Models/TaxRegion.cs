using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("TaxRegion")]
    public class TaxRegion
    {
        public TaxRegion()
        {

        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(15)]
        [Column(TypeName = "VARCHAR")]
        public string code { get; set; }
        [Column(TypeName = "VARCHAR")]
        public string  issuer_code { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string region_name { get; set; }
        [StringLength(250)]
        [Column(TypeName = "VARCHAR")]
        public string description { get; set; } 
        public bool status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}