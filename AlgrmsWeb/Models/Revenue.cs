using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("Revenues")]
    public class Revenue
    {
        public Revenue()
        {
            receptors = new HashSet<Receptor>();
            revenuecharges = new HashSet<RevenueCharge>();
        }
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        //public int id { get; set; }
        [StringLength(8)]
        public string issuer_code { get; set; }
        [MaxLength(8)]
        public string category_code { get; set; }
        [StringLength(8)]
        public string revenue_code { get; set; }
        public string revenue_name { get; set; }
        public string description { get; set; }
        public string frequency { get; set; }
        public decimal amount { get; set; }
        public double rate { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public ICollection<Receptor> receptors { get; set; }
        public ICollection<RevenueCharge> revenuecharges { get; set; }



    }
}