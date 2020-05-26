using Microsoft.AspNet.Identity.EntityFramework;
using Paulo.Data.Context;

namespace Paulo.Data.Identity.Models
{
    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
                                   CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(AppDbContext context)
            : base(context)
        {
        }
    }
}
