using Microsoft.AspNetCore.Identity;

namespace AuthWebApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName {  get; set; }
    }
}
