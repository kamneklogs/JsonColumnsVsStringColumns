using Microsoft.EntityFrameworkCore;

namespace Context;

public class JsonColumnsContext : DbContext
{
    private readonly string? connectionString;

    public JsonColumnsContext()
    {
        connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    }

    public DbSet<ObjectA> WithJsonColumns { get; set; }
    public DbSet<ObjectB> WithString { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ObjectA>()
            .OwnsOne(o => o.NestedObject, c => c.ToJson());
    }
}
