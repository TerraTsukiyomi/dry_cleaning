using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryCleaning.Domain.Entities;
using System.Data.Entity;

namespace DryCleaning.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
    }
}
