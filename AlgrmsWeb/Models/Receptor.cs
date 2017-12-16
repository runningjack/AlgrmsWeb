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
            Revenues = new HashSet<Revenue>();
        }
        [Key]
        public string receptor_code { get; set; }
        public string issuer_code { get; set; }
        public string agent_code { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string other_name { get; set; }
        public string company_name { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }
        public string receptor_type { get; set; }
        public string addresse { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string background { get; set; }
        public string nature_of_business { get; set; }
        public string area_of_business { get; set; }
        public string company_size { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public IEnumerable<Revenue> Revenues { get; set; }

    }
}