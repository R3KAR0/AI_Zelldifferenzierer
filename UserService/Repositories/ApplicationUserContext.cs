using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserServiceModels;
using UserServiceModels.Relationships;

namespace UserService.Repositories
{

    public class ApplicationUserContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// TODO FIX RELATIONSHIP FOLDERCLAIMS
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }

    }

}
