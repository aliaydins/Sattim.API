using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sattim.Entities
{
    public class User
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  userId { get; set; }
        [Required]
        public string userEmail { get; set; }
        [Required]
        public string  userPassword { get; set; }
        [StringLength(50)]
        [Required]
        public string userName { get; set; }
        [StringLength(50)]
        [Required]
        public string  userSurname { get; set; }

        public string userImg { get; set; }
        public int  userBank { get; set; }
       

    }
}
