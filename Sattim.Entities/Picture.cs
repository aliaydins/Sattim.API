using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sattim.Entities
{
    public class Picture
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int pictureId { get; set; }

        public string pictureData { get; set; }

        public int productId { get; set; }

    }
}
