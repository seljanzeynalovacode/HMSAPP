using HMSAPP.Domainn.Entities;
using HMSAPP.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HMSAPP.Persistance.Data;

public class HSDbContext : DbContext
{
    public HSDbContext(DbContextOptions<HSDbContext> options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        // Automatically discovers and applies all IEntityTypeConfiguration implementations from the assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HSDbContext).Assembly);
    }

}
