using AndrewCSharpCodingTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewCSharpCodingTest.Core
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Payment> Payments { get; set; }
    }
}
