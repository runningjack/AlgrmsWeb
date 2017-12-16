﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlgrmsWeb.Models
{
    [Table("TaxCategory")]
    public class TaxCategory
    {
        public TaxCategory()
        {

        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(8)]
        public string category_code { get; set; }
        [StringLength(50)]
        public string title { get; set; }
        [StringLength(500)]
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }


    }
}