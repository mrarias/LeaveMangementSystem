using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveMangementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //this replaces the default ApplicationUser and use ApplicationUser - serves as
    //subsidiary or alternative class to ApplicationUser
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "b0370d96-bf08-46e4-a0a5-e4db75c32647",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "8ad1c185-af0b-4345-ac8b-f0d2c79c4a78",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "5c9c3083-e299-4c58-a73e-1f5e3e873338",
                    Name = "Administrator",
                    NormalizedName = "Administrator"
                });

            //var hasher = new PasswordHasher<ApplicationUser>();
            //builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                    Id = "eb8c6c79-d4c2-4255-bd07-9618293d109f",
                    Email = "arias_melvin@yahoo.com.ph",
                    NormalizedEmail = "ARIAS_MELVIN@YAHOO.COM.PH",
                    NormalizedUserName = "ARIAS_MELVIN@YAHOO.COM.PH",
                    UserName = "arias_melvin@yahoo.com.ph",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1950,12,01)
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> 
                {
                    RoleId = "5c9c3083-e299-4c58-a73e-1f5e3e873338",
                    UserId = "eb8c6c79-d4c2-4255-bd07-9618293d109f"
                });
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
