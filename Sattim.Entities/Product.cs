using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sattim.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }

        [StringLength(80)]
        [Required]
        public string productTitle { get; set; }
        [StringLength(250)]
        [Required]
        public string productExplain { get; set; }
        [StringLength(50)]
        [Required]
        public string productCategory { get; set; }
        [Required]
        public int productPrice { get; set; }
        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime productFirstDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime productLasttDate { get; set; }
        [DefaultValue(0)]
        public bool isSell { get; set; }

        public int userId { get; set; }

       
       
    }
}
