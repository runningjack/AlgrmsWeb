using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("Zones")]
    public class Zone
    {
        public Zone()
        {
            countries = new HashSet<Country>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int zone_id { get; set; }
        public int country_id { get; set; }
        public string state_name { get; set; }
        public string code { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public ICollection<Country> countries { get; set; }
    }
}