using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("TaxForce")]
    public class TaxForce
    {
        public TaxForce()
        {
            taxagents = new HashSet<TaxAgent>();
        }
        
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //public int id { get; set; }
        [Required]
        [StringLength(8)]
        [Column(TypeName = "VARCHAR")]
        public string issuer_code { get; set; }
        [Key]
        [StringLength(8)]
        [Column(TypeName = "VARCHAR")]
        public string task_force_code { get; set; }
        [Required]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string task_force_name { get; set; }
        [StringLength(250)]
        [Column(TypeName = "VARCHAR")]
        public string task_force_description { get; set; }
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string task_force_address { get; set; }
        [Required]
        [StringLength(12)]
        [Column(TypeName = "VARCHAR")]
        public string task_force_phone { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string task_force_email { get; set; }
        public bool view_status { get; set; }
        public bool active_status { get; set; }
        public bool enabled_status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public ICollection<TaxAgent> taxagents { get; set; }
    }
}