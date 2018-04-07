using EntityBeta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace EntityBeta.DAL
{
    public class EntityBetaContext : DbContext
    {

        public EntityBetaContext() : base("OracleBeta"){
        }

        public DbSet<Cadastro> Cadastros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Cadastro>().ToTable("db.cadastro");
        }
    }
}