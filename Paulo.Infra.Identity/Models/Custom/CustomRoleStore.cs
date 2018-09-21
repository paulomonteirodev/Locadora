using Microsoft.AspNet.Identity.EntityFramework;
using Paulo.Infra.Identity.Context;

namespace Paulo.Infra.Identity.Models.Custom
{
    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
