using Microsoft.EntityFrameworkCore;

namespace Trianairo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Saint> Values { get; set; }
    }
}