using Logistica.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistica.DBContext
{
    public class LogisticContext : DbContext
    {
        public LogisticContext(DbContextOptions<LogisticContext> options) : base(options)
        {

        }

        public DbSet<Logistic> Logistics { get; set; }
    }
}
