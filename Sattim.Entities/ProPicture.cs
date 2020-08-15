using System;
using System.Collections.Generic;
using System.Text;

namespace Sattim.Entities
{
    public class ProPicture
    {

        public int productId { get; set; }

        public Picture picture { get; set; }
        public string productTitle { get; set; }
        
        public string productExplain { get; set; }
       
        public string productCategory { get; set; }
        
        public int productPrice { get; set; }
        
        public DateTime productFirstDate { get; set; }
       
        public DateTime productLasttDate { get; set; }
       
        public bool isSell { get; set; }

        public int userId { get; set; }

    }
}
