namespace ListadeCompras.Data
{
    using Microsoft.EntityFrameworkCore;
    using ListadeCompras.Models;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Compras> Compras { get; set; }
    }
}