using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("Issuers")]
    public class Issuer
    {
        public Issuer()
        {
            taxforces = new HashSet<TaxForce>();
            taxagents = new HashSet<TaxAgent>();
            receptors = new HashSet<Receptor>();
            taxregions = new HashSet<TaxRegion>();
            revenuecharges = new HashSet<RevenueCharge>();
            revenues = new HashSet<Revenue>();
            //zones = new HashSet<Zone>();
        }
        [Key]
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(8)]
        public string issuer_code { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string issuer_name { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string issuer_contact_name { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string issuer_conatct_phone { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string issuer_email { get; set; }
        //[Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string issuer_phone { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string issuer_desription { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string issuer_address { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(25)]
        public string issuer_city { get; set; }
        [Column(TypeName = "VARCHAR")]
        [Required]
        [StringLength(25)]
        public string issuer_state { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string issuer_country { get; set; }
        public bool view_status { get; set; }
        public bool active_status { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string issuer_geo_data { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public ICollection<TaxForce> taxforces { get; set; }
        public ICollection<Revenue> revenues { get; set; }
        public ICollection<Receptor> receptors { get; set; }
        public ICollection<TaxRegion> taxregions { get; set; }
        public ICollection<TaxAgent> taxagents { get; set; }
        public ICollection<RevenueCharge> revenuecharges { get; set; }
        //public ICollection<Zone> zones { get; set; }

    }

}