using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CCC2014.Models
{
    public class CCC2014DbContext : DbContext
    {
        public CCC2014DbContext()
            : base("CCC2014Connection")
        {    
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}