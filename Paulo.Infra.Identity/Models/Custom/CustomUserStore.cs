using Microsoft.AspNet.Identity.EntityFramework;
using Paulo.Infra.Identity.Context;

namespace Paulo.Infra.Identity.Models
{
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
                                   CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
