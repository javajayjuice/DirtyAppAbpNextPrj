using Abp.Authorization;
using DirtyAppAbp.Authorization.Roles;
using DirtyAppAbp.Authorization.Users;

namespace DirtyAppAbp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
