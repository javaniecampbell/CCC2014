using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CCC2014.Models
{
    public class CCC2014DbContext : DbContext
    {
        static CCC2014DbContext()
        {
            Database.SetInitializer<CCC2014.Models.CCC2014DbContext>(new MigrateDatabaseToLatestVersion<CCC2014.Models.CCC2014DbContext, CCC2014.Migrations.Configuration>());
           
        }
        public CCC2014DbContext()
            : base("CCC2014Connection")
        {    
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}