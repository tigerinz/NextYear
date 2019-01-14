using CreateNextYear_Core.Enities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace CreateNextYear_Core.Infrastructure
{
    class CreateNextYearDbContext:DbContext
    {
        public DbSet<UA_Account> UA_Account { get; set; }
        public DbSet<UA_Account_sub> UA_Account_sub { get; set; }

        public CreateNextYearDbContext() : base("CreateNextYear") {
            this.Database.Log = s => Console.WriteLine();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UA_Account>().HasKey(e => e.cAcc_Id);
            modelBuilder.Entity<UA_Account_sub>().HasKey(e => new { e.cAcc_Id, e.iYear, e.cSub_Id });
        }
    }
}
