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
        [Key]
        public int id { get; set; }
        public string issuer_code { get; set; }
        
        [StringLength(8)]
        public string agent_code { get; set; }
        [StringLength(50)]
        public string first_name { get; set; }
        [StringLength(50)]
        public string last_name { get; set; }
        [StringLength(50)]
        public string other_name { get; set; }
        public DateTime dob { get; set; }
        [StringLength(10)]
        public string gender { get; set; }
        [StringLength(100)]
        public string address { get; set; }
        [StringLength(25)]
        public string city { get; set; }
        [StringLength(25)]
        public string state { get; set; }
        [StringLength(50)]
        public string country { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }


    }
}