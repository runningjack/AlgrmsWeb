using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("RevenueCharges")]
    public class RevenueCharge
    {
        public RevenueCharge()
        {

        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(8)]
        [Column(TypeName = "VARCHAR")]
        public string issuer_code { get; set; }
        [Required]
        [StringLength(8)]
        [Column(TypeName = "VARCHAR")]
        public string revenue_code { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string title { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string  description { get; set; }
        public double charge_rate { get; set; }
        public decimal charge_amount { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}