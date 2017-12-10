using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("TaskForce")]
    public class TaxForce
    {
        public TaxForce()
        {
            TaxAgents = new HashSet<TaxAgent>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string issuer_code { get; set; }
        
        public string task_force_code { get; set; }
        public string task_force_name { get; set; }
        public string task_force_description { get; set; }
        public string task_force_address { get; set; }
        public string task_force_phone { get; set; }
        public string task_force_email { get; set; }
        public bool view_status { get; set; }
        public bool active_status { get; set; }
        public bool enabled_status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public IEnumerable<TaxAgent> TaxAgents { get; set; }
    }
}