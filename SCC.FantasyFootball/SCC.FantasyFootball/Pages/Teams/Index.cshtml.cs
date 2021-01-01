using Microsoft.Extensions.Logging;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Teams
{
    public class IndexModel : AnoynBase<IndexModel>
    {

        private readonly IEntitiesManager<TeamDto> _teamsManager;
        public IndexModel(IEntitiesManager<TeamDto> teamsManager, ILogger<IndexModel> logger):base(logger) 
        {
            _teamsManager = teamsManager;
        }


        public PagedList<TeamDto> PagedRecords { get;set; } 

        public async Task OnGetAsync(int? pageIndex)
        {
            LogUserInfo();

            if (PagedRecords == null)
                PagedRecords = new PagedList<TeamDto>();
            if (pageIndex.HasValue)
                PagedRecords.CurrentPage = pageIndex.Value;
            PagedRecords = await _teamsManager.GetPageAsync(PagedRecords);
        }
    }
}
