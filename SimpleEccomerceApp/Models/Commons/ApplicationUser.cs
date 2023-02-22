using Microsoft.AspNetCore.Identity;

namespace SimpleEcommerceApp.Models.Commons
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => FirstName + " " + LastName;
        public DateTime Dob { get; set; }
    }
}
