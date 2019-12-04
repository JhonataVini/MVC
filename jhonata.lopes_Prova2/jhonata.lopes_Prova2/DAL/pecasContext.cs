using jhonata.lopes_Prova2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace jhonata.lopes_Prova2.DAL
{
    public class PecasContext: DbContext
    {
        public PecasContext(): base("PecasContext")
        {
        }
        public DbSet<Pecas> pecas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}