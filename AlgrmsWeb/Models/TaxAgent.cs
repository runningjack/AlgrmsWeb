using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("TaxAgents")]
    public class TaxAgent
    {
        public TaxAgent()
        {

        }
        
       
        [Required]
        [StringLength(8)]
        [Column(TypeName = "VARCHAR")]
        public string issuer_code { get; set; }
        [Required]
        [StringLength(8)]
        [Column(TypeName = "VARCHAR")]
        public string tax_force_code { get; set; }
        [Key]
        [StringLength(12)]
        [Column(TypeName = "VARCHAR")]
        public string agent_code { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string first_name { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string last_name { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string other_name { get; set; }
        public DateTime dob { get; set; }
        [StringLength(5)]
        [Column(TypeName = "VARCHAR")]
        public string gender { get; set; }
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string address { get; set; }
        [StringLength(25)]
        [Column(TypeName = "VARCHAR")]
        public string city { get; set; }
        [StringLength(25)]
        [Column(TypeName = "VARCHAR")]
        public string state { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string country { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }


    }
}