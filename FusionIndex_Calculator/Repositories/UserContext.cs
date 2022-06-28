using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserServiceModels;

namespace FusionIndex_Calculator.Repositories
{

    public class UserContext : IdentityDbContext<ApplicationUser>
    {
        public UserContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

        /// <summary>
        /// TODO FIX RELATIONSHIP FOLDERCLAIMS
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<UserGroups>()
               .HasKey(ug => new {ug.UserId, ug.GroupId});

           modelBuilder.Entity<UserGroups>()
               .HasOne(ug => ug.User)
               .WithMany(u => u.Groups)
               .HasForeignKey(ug => ug.UserId);

           modelBuilder.Entity<UserGroups>()
               .HasOne(ug => ug.Group)
               .WithMany(g => g.Groups)
               .HasForeignKey(g => g.GroupId);
           modelBuilder.Entity<FolderClaim>()
               .HasKey(fc => new {fc.FolderId, fc.GroupId});
           modelBuilder.Entity<FolderClaim>()
               .HasOne(fc => fc.Group)
               .WithMany(g => g.Claims)
               .OnDelete(DeleteBehavior.Cascade)
               .HasForeignKey(fc => fc.GroupId);

           */
            base.OnModelCreating(modelBuilder);
        }

    }

}
