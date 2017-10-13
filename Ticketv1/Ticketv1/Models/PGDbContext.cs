using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ticketv1.Models
{
    public class PGDbContext : DbContext
    {
        public PGDbContext() : base(nameOrConnectionString: "DefaultConnectionString") { }
        public virtual DbSet<User> users { get; set; }

        public System.Data.Entity.DbSet<Ticketv1.Models.Event> events { get; set; }
    }
}
