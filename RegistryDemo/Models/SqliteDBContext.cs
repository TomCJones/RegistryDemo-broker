// SqliteDBConetext.cs copyright tomjones
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RegistryDemo.Models
{
    public class SqliteDBContext : DbContext
    { 
        public SqliteDBContext (DbContextOptions<SqliteDBContext> options)  : base(options)
        {
        }

        public DbSet<RegisteredObject> RegisteredObjects { get; set; }

        public async Task<IEnumerable<RegisteredObject>> GetObjectsAsync()
        {
            var items = await RegisteredObjects.ToListAsync().ConfigureAwait(false);
            return items;
        }
    }
}
