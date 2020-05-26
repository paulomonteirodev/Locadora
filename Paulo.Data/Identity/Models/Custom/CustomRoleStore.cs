using Microsoft.AspNet.Identity.EntityFramework;
using Paulo.Data.Context;

namespace Paulo.Data.Identity.Models.Custom
{
    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(AppDbContext context)
            : base(context)
        {
        }
    }
}
