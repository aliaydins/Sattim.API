using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sattim.Entities
{
    public class Offer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int offerId { get; set; }
        [Required]
        public int offer { get; set; }
        [DefaultValue(0)]
        public bool isDone { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime offerDate { get; set; }
        [Required]
        public int offerByuserId { get; set; }

        public int productId { get; set; }
        public int userId { get; set; }

    }
}
