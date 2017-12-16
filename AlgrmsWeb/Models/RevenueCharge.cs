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
        public string issuer_code { get; set; }
        public string revenue_code { get; set; }
        public string title { get; set; }
        public string  description { get; set; }
        public double charge_rate { get; set; }
        public decimal charge_amount { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}