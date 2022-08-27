using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;

namespace Pierre.Models
{
  public class PierreContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers {get; set;}

    public DbSet<FlavorTreat> FlavorTreat { get; set; }

    public PierreContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<IdentityRole>().HasData(new IdentityRole { 
        Id = "bf7441ce-98a5-4128-bd17-cb980d1cd2c5", 
        Name = "Admin", 
        NormalizedName = "ADMIN", 
        ConcurrencyStamp = Guid.NewGuid().ToString() });

      var hasher = new PasswordHasher<IdentityUser>();

      builder.Entity<ApplicationUser>().HasData(
        new ApplicationUser
        {
          Id = "3ca56c49-d3c8-4216-8d39-8f03c9db9acf",
          UserName = "Pierre",
          NormalizedUserName = "PIERRE",
          PasswordHash = hasher.HashPassword(null, "Pierre'sTr34ts")
        }
      );

      builder.Entity<IdentityUserRole<string>>().HasData(
        new IdentityUserRole<string>
        {
          RoleId = "bf7441ce-98a5-4128-bd17-cb980d1cd2c5",
          UserId = "3ca56c49-d3c8-4216-8d39-8f03c9db9acf"
        }
      );
    }
  }
}