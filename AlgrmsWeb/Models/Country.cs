using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("Country")]
    public class Country
    {
        public Country()
        {
            zones = new HashSet<Zone>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int country_id { get; set; }
        [MaxLength(3)]
        public string iso_code_3 { get; set; }
        [MaxLength(250)]
        public string country_name { get; set; }
        public int phone_code { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public ICollection<Zone> zones { get; set; }
    }
}