using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.Areas.Identity.Data;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.PagePolicy
{
    public abstract class PolicyBase : PageModel
    {
        
        public bool IsCreator { get; set; }
        public bool IsEditor { get; set; }      
    }

    [AllowAnonymous]

    public class AnoynBase : PolicyBase
    {

    }
}
