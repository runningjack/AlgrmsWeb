using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        //public int id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(8)]
        public string issuer_code { get; set; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(8)]
        public string category_code { get; set; }
        [Key]
        [StringLength(8)]
        [Column(TypeName = "VARCHAR")]
        public string revenue_code { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string revenue_name { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string description { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string frequency { get; set; }
        public decimal amount { get; set; }
        public double rate { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public virtual ICollection<Receptor> receptors { get; set; }
        public ICollection<RevenueCharge> revenuecharges { get; set; }
        [NotMapped]
        public SelectList CategoryList { get; set; }



    }
}