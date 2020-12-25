using Microsoft.AspNetCore.Mvc.RazorPages;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;
using System.Threading.Tasks;


namespace SCC.FantasyFootball.Pages.Stats
{
    public class IndexModel : ViewBasePage
    {
        private readonly IMultiEntitiesManager<StatDto> _statManager;

        public IndexModel(IMultiEntitiesManager<StatDto> sm)
        {
            _statManager = sm;
        }


        public PagedList<StatDto> PagedRecords { get; set; }


        public async Task OnGetAsync(int? pageIndex)
        {
            if (PagedRecords == null)
                PagedRecords =  new PagedList<StatDto>();
            if (pageIndex.HasValue)
                PagedRecords.CurrentPage = pageIndex.Value;
            PagedRecords = await _statManager.GetPageAsync(PagedRecords);
        }
    }
}
