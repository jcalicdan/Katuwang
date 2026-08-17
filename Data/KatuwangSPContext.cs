using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Katuwang.Models.StoredProcedure;
using Katuwang.Models;

namespace Katuwang.Data
{
    public class KatuwangSPContext : DbContext
    {
        public KatuwangSPContext(DbContextOptions<KatuwangSPContext> options)
            : base(options)
        {

        }

        public DbSet<Dashboard> Dashboard { get; set; }

        public DbSet<Masterlist> Masterlist { get; set; }

        public DbSet<AddressDirectory> AddressDirectory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressDirectory>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("Index");
            });
        }
    }
}
