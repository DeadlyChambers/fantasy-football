using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.DataAccess;

namespace SCC.FantasyFootball.PagePolicy
{
    /// <summary>
    /// Any page that requires a login at the minimum
    /// </summary>
    [Authorize(Roles = SCCRoleConst.Admin)]
    public class UpdateBasePage : PageModel
    {
    }
}
