using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;


#nullable disable

namespace Havan.Desafio.DataAccess.Entities
{
    public partial class HavanContext : DbContext
    {
        public HavanContext()
        {
        }

        public HavanContext(DbContextOptions<HavanContext> options)
            : base(options)
        {
        }

        public readonly ITenantProvider TenantProvider;
        public HavanContext(DbContextOptions<HavanContext> options, ITenantProvider tenantProvider)
            : base(options)
        {
            TenantProvider = tenantProvider;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string ConnectionString = TenantProvider.GetTenantConnectionString();
                base.OnConfiguring(optionsBuilder);
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);        
    }
}
