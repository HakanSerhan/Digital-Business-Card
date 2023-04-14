using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalBusinessCard.Models.Classes
{
    public class Context : DbContext
    {
        public DbSet<BusinessCard> BusinessCards { get; set; }
        public DbSet<Users> Userss { get; set; }
    }
}