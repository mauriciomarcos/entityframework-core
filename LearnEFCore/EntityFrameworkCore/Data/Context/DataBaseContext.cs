using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data.Context
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=blog.db");
        }
    }
}
