using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalBusinessCard.Models.Classes
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(80)]

        public string UserName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(80)]
        public string Password { get; set; }

        [StringLength(80)]
        public string Email { get; set; }
   
        public bool Verified { get; set; }
        public string UserRole { get; set; }
        public ICollection<BusinessCard> BusinessCards { get; set; }
    }
}