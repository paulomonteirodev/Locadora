using Microsoft.AspNet.Identity.EntityFramework;

namespace Paulo.Infra.Identity.Models
{
    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}
