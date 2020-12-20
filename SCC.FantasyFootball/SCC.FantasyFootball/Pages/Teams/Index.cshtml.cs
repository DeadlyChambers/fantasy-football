using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DTO;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly ITeamsManager _teamsManager;
        public IndexModel(ITeamsManager teamsManager)
        {
            _teamsManager = teamsManager;
        }


        public PagedList<TeamDto> PagedRecords { get;set; } 

        public async Task OnGetAsync(int? pageIndex)
        {
            if (PagedRecords == null)
                PagedRecords = new PagedList<TeamDto>();
            if (pageIndex.HasValue)
                PagedRecords.CurrentPage = pageIndex.Value;
            PagedRecords = await _teamsManager.GetPageAsync(PagedRecords);
        }
    }
}
