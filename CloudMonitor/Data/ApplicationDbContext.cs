using CloudMonitor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudMonitor.Data;

public class ApplicationDbContext : IdentityDbContext
{
    DbSet<MonitoringData> MonitoringDatas { get; set; }
    DbSet<Configuration> Configurations { get; set; }
    DbSet<User> Users { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed a new "admin" role
        SeedRoles(builder);

        // Seed a new admin user and associate it with the "admin" role
        SeedUsers(builder);
        SeedUserRoles(builder);
    }
    
    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                Name = "admin",
                NormalizedName = "ADMIN"
            });
    }
    private void SeedUsers(ModelBuilder builder)
    {
        var hasher = new PasswordHasher<IdentityUser>();

        builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@cloudmonitor.de",
                NormalizedUserName = "ADMIN@CLOUDMONITOR.DE",
                Email = "admin@cloudmonitor.de",
                NormalizedEmail = "ADMIN@CLOUDMONITOR.DE",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin*123"),
                SecurityStamp = string.Empty
            });
    }
    
    private void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
            });
    }
}