using System.Security.Cryptography.X509Certificates;
using CleanArchitecture.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker.Entries<Entity>();
        foreach (var entry in entries)
        {
            if(entry.State==EntityState.Added)
                entry.Property(x=>x.CreatedDate).CurrentValue=DateTime.Now;
           if(entry.State==EntityState.Modified)
               entry.Property(x=>x.UpdatedDate).CurrentValue=DateTime.Now;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}