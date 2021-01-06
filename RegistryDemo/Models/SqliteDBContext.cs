// SqliteDBConetext.cs copyright tomjones
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RegistryDemo.Models
{
    public class SqliteDBContext : DbContext
    { 
        public SqliteDBContext (DbContextOptions<SqliteDBContext> options)  : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Database.EnsureCreated();
            Database.Migrate();
            if (this.RegisteredObjects.Any())
            {
                return;
            }
        }

        string _dbPath;
        public DbSet<RegisteredObject> RegisteredObjects { get; set; }
    }
}
