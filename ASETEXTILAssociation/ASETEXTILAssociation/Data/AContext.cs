using ASETEXTILAssociation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Data
{
    public class AContext:IdentityDbContext<IdentityUser>
    {
        public AContext(DbContextOptions<AContext> options) : base(options)
        {
        }

        public DbSet<Credit> Credits { get; set; }
        public DbSet<CreditType> CreditType { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<SavingType> SavingType { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Affiliate> Affiliates { get; set; }
        public DbSet<PaymentPlan> PaymentPlans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<CreditType>().HasOne(c=>c.Credits).WithMany(t=>t.CreditType)
        }
    }
}
