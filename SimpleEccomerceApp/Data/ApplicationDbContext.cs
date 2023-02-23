using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleEcommerceApp.Models.Commons;
using SimpleEcommerceApp.Data.Configurations;
using SimpleEcommerceApp.Models;
using SimpleEcommerceApp.Models.Products;

namespace SimpleEcommerceApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Identity configuration
            builder.Entity<IdentityUserClaim<int>>(options =>
            {
                options.ToTable("UserClaims");
                options.HasKey(x => x.Id);
            });

            builder.Entity<IdentityUserRole<int>>(options =>
            {
                options.ToTable("UserRoles");
                options.HasKey(x => new { x.UserId, x.RoleId });
            });

            builder.Entity<IdentityRoleClaim<int>>(options =>
            {
                options.ToTable("RoleClaims");
                options.HasKey(x => x.Id);
            });

            builder.Entity<IdentityUserLogin<int>>(options =>
            {
                options.ToTable("UserLogins");
                options.HasKey(x => x.UserId);
            });

            builder.Entity<IdentityUserToken<int>>(options =>
            {
                options.ToTable("UserTokens");
                options.HasKey(x => x.UserId);
            });
            builder.ApplyConfiguration<ApplicationUser>(new ApplicationUserConfiguration());
            builder.ApplyConfiguration<ApplicationRole>(new ApplicationRoleConfiguration());
            #endregion
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}