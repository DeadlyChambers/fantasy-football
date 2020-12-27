using Microsoft.Extensions.Logging;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.PagePolicy;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Pages.Players
{
    public class IndexModel : AnoynBase<IndexModel>
    {
        private readonly IEntitiesManager<PlayerDto> _playersManager;

        public IndexModel(IEntitiesManager<PlayerDto> playersManager, ILogger<IndexModel> logger) : base(logger)
        {
            _playersManager = playersManager;
        }

        public PagedList<PlayerDto> PagedRecords { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            if (PagedRecords == null)
                PagedRecords = new PagedList<PlayerDto>();
            if (pageIndex.HasValue)
                PagedRecords.CurrentPage = pageIndex.Value;
            PagedRecords = await _playersManager.GetPageAsync(PagedRecords);
        }
    }
}
