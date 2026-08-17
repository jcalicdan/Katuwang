using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Katuwang.Models;

namespace Katuwang.Data
{
    public class KatuwangContext : DbContext
    {
        public KatuwangContext (DbContextOptions<KatuwangContext> options)
            : base(options)
        {

        }

        public DbSet<Masterlist> Masterlist { get; set; }

        public DbSet<Transfer> Transfer { get; set; }

        public DbSet<R401> R401 { get; set; }

        public DbSet<Maytungkulin> Maytungkulin { get; set; }

        public DbSet<Destinado> Destinado { get; set; }

        public DbSet<AttendanceWeekly> AttendanceWeekly { get; set; }

        public DbSet<SystemParameter> SystemParameter { get; set; }
    }
}
