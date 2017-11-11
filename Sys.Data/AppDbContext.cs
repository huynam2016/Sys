using Microsoft.AspNet.Identity.EntityFramework;
using Sys.Entity;
using System.Data.Entity;

namespace Sys.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AppPermission> AppPermissions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasKey<string>(r => r.Id).ToTable("AppRoles");
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("AppUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("AppUserLogins");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("AppUserClaims");
        }
    }
}
