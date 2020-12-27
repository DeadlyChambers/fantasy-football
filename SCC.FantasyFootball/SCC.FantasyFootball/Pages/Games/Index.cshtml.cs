using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Games
{
    public class IndexModel : AnoynBase<IndexModel>
    {
        private readonly IEntitiesManager<GameDto> _entitiesManager;

        public IndexModel(IEntitiesManager<GameDto> entitiesManager, ILogger<IndexModel> logger) : base(logger)
        {
            _entitiesManager = entitiesManager;
        }

        public PagedList<GameDto> PagedRecords { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            if (PagedRecords == null)
                PagedRecords = new PagedList<GameDto>();
            if (pageIndex.HasValue)
                PagedRecords.CurrentPage = pageIndex.Value;
            PagedRecords = await _entitiesManager.GetPageAsync(PagedRecords);
        }
    }
}
