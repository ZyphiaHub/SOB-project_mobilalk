using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAppRestAPIBackEnd.Model;

public class AppDbContext : DbContext
{
    public DbSet<DBData> DBData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=posts.db3");  // Adatbázis elérési út
    }
}
