using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Teams
{
    public class IndexModel : AnoynBase
    {
        private readonly IAuthorizationService _auth;
        private readonly IEntitiesManager<TeamDto> _teamsManager;
        public IndexModel(IEntitiesManager<TeamDto> teamsManager, IAuthorizationService auth)
        {
            _teamsManager = teamsManager;
            _auth = auth;
        }


        public PagedList<TeamDto> PagedRecords { get;set; } 

        public async Task OnGetAsync(int? pageIndex)
        {
            //IsCreator = _auth.AuthorizeAsync(User, SCCPolicies.Creators).Result.Succeeded;
            //IsEditor = _auth.AuthorizeAsync(User, SCCPolicies.Updaters).Result.Succeeded;
            if (PagedRecords == null)
                PagedRecords = new PagedList<TeamDto>();
            if (pageIndex.HasValue)
                PagedRecords.CurrentPage = pageIndex.Value;
            PagedRecords = await _teamsManager.GetPageAsync(PagedRecords);
        }
    }
}
