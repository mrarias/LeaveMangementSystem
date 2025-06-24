using Microsoft.AspNetCore.Identity;

namespace LeaveMangementSystem.Web.Data
{
    // extends ApplicationUser from ApplicationUser through inheritance
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
